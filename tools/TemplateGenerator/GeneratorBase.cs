using System.CommandLine;
using System.CommandLine.Parsing;
using System.Text.RegularExpressions;
using Scriban;
using JetBrains.Annotations;
using Scriban.Runtime;

namespace TemplateGenerator;

internal abstract partial class GeneratorBase : IGenerator
{
    [GeneratedRegex(@"^(\d+)\.")]
    private static partial Regex ProblemNumberRegex();

    private const string InvalidNamespaceChars = " `-=~!@#$%^&*()+[]{}',.;";
    private const int ProblemNumberLength = 4;
    private const char ReplacementChar = '_';
    internal static readonly string ProblemsFolderPath = Path.Combine(FindRepoRoot(), "src", "LeetCode.Problems");
    internal static readonly string LeetCodeFolderPath = Path.Combine(ProblemsFolderPath, "!WIP");

    protected readonly Option<string> TitleOption = new("--title") { Description = "Problem title", Required = true };

    private readonly List<GeneratedFile> _files = [];

    /// <summary>
    /// The problem's folder name under <c>!WIP</c>, e.g. <c>0001 Two Sum</c>.
    /// </summary>
    public string FolderName { get; private set; } = string.Empty;

    /// <summary>
    /// The files <see cref="Generate" /> rendered, in order; nothing is written until <see cref="ProblemPlacer" /> places them.
    /// </summary>
    public IReadOnlyList<GeneratedFile> Files => _files;

    [UsedImplicitly]
    public string EscapedTitle { get; private set; } = string.Empty;

    [UsedImplicitly]
    public string Namespace { get; private set; } = string.Empty;

    public abstract string CommandName { get; }
    public abstract string CommandDescription { get; }

    public virtual void ConfigureCommand(Command command)
    {
        command.Add(TitleOption);
    }

    public virtual void SetOptions(ParseResult parseResult)
    {
        var title = parseResult.GetValue(TitleOption)
            ?? throw new InvalidOperationException("Title is required");
        Init(title);
    }

    public void Init(string title)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);

        var titleWithUnifiedProblemNumber = ProblemNumberRegex().Replace(title, match => match.Groups[1].Value.PadLeft(ProblemNumberLength, '0'));
        UseFolderName(ReplaceChars(titleWithUnifiedProblemNumber, Path.GetInvalidFileNameChars().Append('.').ToArray()));
    }

    /// <summary>
    /// Targets an existing folder, so the rendered namespace matches the files already stored there.
    /// </summary>
    public void UseFolderName(string folderName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(folderName);

        FolderName = folderName;
        EscapedTitle = $"_{ReplaceChars(folderName, InvalidNamespaceChars.ToCharArray())}";
        Namespace = GenerateTemplate("namespace LeetCode.Problems.{{ EscapedTitle }};");
    }

    public abstract void Generate();

    private static string ReplaceChars(string str, char[] chars) => string.Join(ReplacementChar, str.Split(chars));

    protected void GenerateFile(string fileName, string template)
    {
        if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
        {
            throw new ArgumentException($"Invalid file name: {fileName}", nameof(fileName));
        }

        var content = GenerateTemplate(template);

        // Normalize line endings to CRLF for Windows/Visual Studio
        content = content.Replace("\r\n", "\n").Replace("\n", "\r\n");

        if (!content.EndsWith("\r\n"))
        {
            content += "\r\n";
        }

        _files.Add(new GeneratedFile(fileName, content));
    }

    protected string GenerateTemplate(string template)
    {
        var scriptObject = new ScriptObject();
        scriptObject.Import(this, renamer: member => member.Name);

        var ctx = new TemplateContext
        {
            MemberRenamer = member => member.Name,
            StrictVariables = true
        };

        ctx.PushGlobal(scriptObject);
        return Template.Parse(template).Render(ctx);
    }

    /// <summary>
    /// The repo root is the nearest folder above the tool's output that holds LeetCode.slnx.
    /// </summary>
    internal static string FindRepoRoot()
    {
        for (var dir = new DirectoryInfo(AppContext.BaseDirectory); dir != null; dir = dir.Parent)
        {
            if (File.Exists(Path.Combine(dir.FullName, "LeetCode.slnx")))
            {
                return dir.FullName;
            }
        }

        throw new DirectoryNotFoundException($"No LeetCode.slnx above {AppContext.BaseDirectory}");
    }
}

