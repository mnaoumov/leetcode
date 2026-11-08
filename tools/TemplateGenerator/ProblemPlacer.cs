using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;

namespace TemplateGenerator;

/// <summary>
/// Puts a generated problem into <c>!WIP</c>. A problem stored already, in <c>!WIP</c> or in its numbered bucket, is
/// reused: a bucket folder is moved back into <c>!WIP</c>, and the fresh files are merged into it rather than written
/// over it. The merge keeps every stored solution, adds only the test cases that are new, and writes any other file
/// that differs beside the stored one as <c>&lt;name&gt;.new</c>, which the build ignores.
/// </summary>
internal sealed partial class ProblemPlacer
{
    internal const string NewFileSuffix = ".new";

    [GeneratedRegex(@"^(\d{4}) ")]
    private static partial Regex ProblemFolderRegex();

    [GeneratedRegex(@"^TestCase(?<Number>\d+)(?<Extension>\.\w+)$")]
    private static partial Regex TestCaseFileRegex();

    [GeneratedRegex(@"\s+")]
    private static partial Regex WhitespaceRegex();

    private const int BucketPrefixLength = 2;
    private const string SchemaProperty = "$schema";
    private const string SolutionFilePrefix = "Solution";
    private const string WipFolderName = "!WIP";

    private readonly Action<string, string> _moveFolder;
    private readonly TextWriter _output;
    private readonly string _problemsFolderPath;

    public ProblemPlacer(string problemsFolderPath, Action<string, string> moveFolder, TextWriter output)
    {
        _problemsFolderPath = problemsFolderPath;
        _moveFolder = moveFolder;
        _output = output;
    }

    private string WipFolderPath => Path.Combine(_problemsFolderPath, WipFolderName);

    /// <summary>
    /// Finds the stored folder, retargets the generator to it, renders the files, then writes or merges them.
    /// </summary>
    /// <returns>The <c>!WIP</c> folder the problem is in now.</returns>
    public string Place(IGenerator generator)
    {
        var existingFolder = FindExistingFolder(generator.FolderName);

        if (existingFolder == null)
        {
            generator.Generate();
            var newFolder = Path.Combine(WipFolderPath, generator.FolderName);
            Directory.CreateDirectory(newFolder);

            foreach (var file in generator.Files)
            {
                File.WriteAllText(Path.Combine(newFolder, file.Name), file.Content);
            }

            _output.WriteLine($"Created {WipFolderName}/{generator.FolderName}");
            return newFolder;
        }

        var folderName = Path.GetFileName(existingFolder);
        var wipFolder = Path.Combine(WipFolderPath, folderName);

        if (!PathsEqual(existingFolder, wipFolder))
        {
            if (Directory.Exists(wipFolder))
            {
                throw new InvalidOperationException($"Cannot move {existingFolder} back: {wipFolder} already exists");
            }

            Directory.CreateDirectory(WipFolderPath);
            _moveFolder(existingFolder, wipFolder);
            _output.WriteLine($"Moved {Path.GetRelativePath(_problemsFolderPath, existingFolder)} -> {WipFolderName}/{folderName}");
        }

        if (folderName != generator.FolderName)
        {
            _output.WriteLine($"Kept the stored folder name '{folderName}' (the fresh title gives '{generator.FolderName}')");
            generator.UseFolderName(folderName);
        }

        generator.Generate();
        Merge(wipFolder, generator.Files, true);
        return wipFolder;
    }

    /// <summary>
    /// Merges a finished <c>!WIP</c> folder into its stored bucket folder. Its solutions are real work rather than
    /// fresh stubs, so one that differs from the stored file is written beside it as <c>&lt;name&gt;.new</c>.
    /// </summary>
    internal void MergeFinished(string folder, IReadOnlyList<GeneratedFile> files)
    {
        Merge(folder, files, false);
    }

    /// <summary>
    /// <c>!WIP</c> first, then the numbered bucket; a problem with no number is matched by its exact name in <c>!WIP</c>.
    /// </summary>
    internal string? FindExistingFolder(string folderName)
    {
        var numberMatch = ProblemFolderRegex().Match(folderName);

        if (!numberMatch.Success)
        {
            var wipFolder = Path.Combine(WipFolderPath, folderName);
            return Directory.Exists(wipFolder) ? wipFolder : null;
        }

        var prefix = numberMatch.Value;
        var searchFolders = new[] { WipFolderPath, Path.Combine(_problemsFolderPath, prefix[..BucketPrefixLength]) };

        foreach (var searchFolder in searchFolders)
        {
            if (!Directory.Exists(searchFolder))
            {
                continue;
            }

            var match = Directory.GetDirectories(searchFolder, $"{prefix}*").Order().FirstOrDefault();

            if (match != null)
            {
                return match;
            }
        }

        return null;
    }

    private void Merge(string folder, IReadOnlyList<GeneratedFile> files, bool solutionsAreStubs)
    {
        var freshTestCases = new List<GeneratedFile>();

        foreach (var file in files)
        {
            if (TestCaseFileRegex().IsMatch(file.Name))
            {
                freshTestCases.Add(file);
                continue;
            }

            var path = Path.Combine(folder, file.Name);

            if (solutionsAreStubs && file.Name.StartsWith(SolutionFilePrefix, StringComparison.Ordinal))
            {
                var hasStoredSolution = Directory.GetFiles(folder, $"{SolutionFilePrefix}*{Path.GetExtension(file.Name)}").Length > 0;

                if (!hasStoredSolution)
                {
                    File.WriteAllText(path, file.Content);
                    _output.WriteLine($"Added {file.Name}");
                }

                continue;
            }

            if (!File.Exists(path))
            {
                File.WriteAllText(path, file.Content);
                _output.WriteLine($"Added {file.Name}");
                continue;
            }

            if (NormalizeText(File.ReadAllText(path)) == NormalizeText(file.Content))
            {
                continue;
            }

            File.WriteAllText(path + NewFileSuffix, file.Content);
            _output.WriteLine($"DIFFERS: {file.Name} - the fresh version is in {file.Name}{NewFileSuffix}; reconcile them and delete it");
        }

        MergeTestCases(folder, freshTestCases);
    }

    private void MergeTestCases(string folder, List<GeneratedFile> freshTestCases)
    {
        var stored = Directory.GetFiles(folder, "TestCase*")
            .Select(path => (Path: path, Match: TestCaseFileRegex().Match(Path.GetFileName(path))))
            .Where(entry => entry.Match.Success)
            .Select(entry => new StoredTestCase(entry.Path, int.Parse(entry.Match.Groups["Number"].Value), entry.Match.Groups["Extension"].Value))
            .ToList();
        var storedContents = stored.Select(testCase => File.ReadAllText(testCase.Path)).ToList();
        var toAdd = new List<GeneratedFile>();

        foreach (var fresh in freshTestCases)
        {
            if (storedContents.Concat(toAdd.Select(file => file.Content)).Any(content => TestCasesEqual(content, fresh.Content)))
            {
                continue;
            }

            toAdd.Add(fresh);
        }

        if (toAdd.Count == 0)
        {
            return;
        }

        var lastNumber = stored.Count == 0 ? 0 : stored.Max(testCase => testCase.Number);
        var width = (lastNumber + toAdd.Count).ToString().Length;

        foreach (var testCase in stored)
        {
            var paddedName = $"TestCase{testCase.Number.ToString().PadLeft(width, '0')}{testCase.Extension}";
            var paddedPath = Path.Combine(folder, paddedName);

            if (!PathsEqual(testCase.Path, paddedPath))
            {
                File.Move(testCase.Path, paddedPath);
            }
        }

        foreach (var (file, index) in toAdd.Select((file, index) => (file, index)))
        {
            var extension = TestCaseFileRegex().Match(file.Name).Groups["Extension"].Value;
            var name = $"TestCase{(lastNumber + index + 1).ToString().PadLeft(width, '0')}{extension}";
            File.WriteAllText(Path.Combine(folder, name), file.Content);
            _output.WriteLine($"Added {name}, a new test case");
        }
    }

    /// <summary>
    /// JSON test cases compare by structure, ignoring <c>$schema</c>, so a reformatted file still matches; anything
    /// else compares with its whitespace collapsed.
    /// </summary>
    internal static bool TestCasesEqual(string left, string right)
    {
        var leftJson = TryParseJson(left);
        var rightJson = TryParseJson(right);

        if (leftJson != null && rightJson != null)
        {
            return JsonNode.DeepEquals(leftJson, rightJson);
        }

        return NormalizeText(left) == NormalizeText(right);
    }

    private static JsonNode? TryParseJson(string text)
    {
        try
        {
            var node = JsonNode.Parse(text);

            if (node is JsonObject obj)
            {
                obj.Remove(SchemaProperty);
            }

            return node;
        }
        catch (JsonException)
        {
            return null;
        }
    }

    private static string NormalizeText(string text) => WhitespaceRegex().Replace(text, " ").Trim();

    private static bool PathsEqual(string left, string right) =>
        string.Equals(Path.GetFullPath(left), Path.GetFullPath(right), StringComparison.OrdinalIgnoreCase);

    private sealed record StoredTestCase(string Path, int Number, string Extension);
}
