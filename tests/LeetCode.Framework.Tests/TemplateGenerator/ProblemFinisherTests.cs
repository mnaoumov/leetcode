using TemplateGenerator;

namespace LeetCode.Framework.Tests.TemplateGenerator;

public class ProblemFinisherTests
{
    private const string WipName = "0001 Two Sum";
    private const string StoredName = "0001 Sum of Two";
    private const string FirstTestCase = """{ "nums": [1], "output": [0] }""";
    private const string SecondTestCase = """{ "nums": [2], "output": [1] }""";

    private string _problemsFolder = string.Empty;
    private StringWriter _output = new();
    private StringWriter _error = new();
    private int _diffCount;

    private string WipFolder => Path.Combine(_problemsFolder, "!WIP");

    private string Bucket => Path.Combine(_problemsFolder, "00");

    [SetUp]
    public void SetUp()
    {
        _problemsFolder = Path.Combine(Path.GetTempPath(), $"ProblemFinisherTests-{Guid.NewGuid():N}");
        Directory.CreateDirectory(WipFolder);
        _output = new StringWriter();
        _error = new StringWriter();
        _diffCount = 0;
    }

    [TearDown]
    public void TearDown()
    {
        _output.Dispose();
        _error.Dispose();
        Directory.Delete(_problemsFolder, true);
    }

    [Test]
    public void Finish_FreeDestination_MovesAndSummarizes()
    {
        CreateFolder(WipFolder, WipName, "// finished");

        var exitCode = Finish(string.Empty, 1);

        Assert.That(exitCode, Is.Zero);
        Assert.That(Directory.Exists(Path.Combine(Bucket, WipName)), Is.True);
        Assert.That(Directory.Exists(Path.Combine(WipFolder, WipName)), Is.False);
        Assert.That(_output.ToString(), Does.Contain("moved 1, merged 0, overwritten 0, skipped 0, failed 0"));
    }

    [Test]
    public void Finish_StoredUnderAnotherTitle_DoesNotCreateASecondFolder()
    {
        CreateFolder(WipFolder, WipName, "// finished");
        CreateFolder(Bucket, StoredName, "// stored");

        Finish("s\n", 1);

        Assert.That(Directory.GetDirectories(Bucket).Select(Path.GetFileName), Is.EqualTo(new[] { StoredName }));
        Assert.That(Directory.Exists(Path.Combine(WipFolder, WipName)), Is.True);
        Assert.That(_error.ToString(), Does.Contain($"00/{StoredName} already exists"));
    }

    [Test]
    public void Finish_ExplicitSkip_IsReportedAndIsNotAFailure()
    {
        CreateFolder(WipFolder, WipName, "// finished");
        CreateFolder(Bucket, WipName, "// stored");

        var exitCode = Finish("skip\n", 1);

        Assert.That(exitCode, Is.Zero);
        Assert.That(_error.ToString(), Does.Contain("0001: skipped"));
        Assert.That(_output.ToString(), Does.Contain("skipped 1, failed 0"));
    }

    [Test]
    public void Finish_ConflictWithNoAnswer_FailsAndLeavesBothFolders()
    {
        CreateFolder(WipFolder, WipName, "// finished");
        CreateFolder(Bucket, StoredName, "// stored");

        var exitCode = Finish(string.Empty, 1);

        Assert.That(exitCode, Is.EqualTo(1));
        Assert.That(_error.ToString(), Does.Contain("0001: FAILED - no answer"));
        Assert.That(_output.ToString(), Does.Contain("moved 0, merged 0, overwritten 0, skipped 0, failed 1"));
        Assert.That(ReadSolution(Bucket, StoredName), Is.EqualTo("// stored"));
        Assert.That(ReadSolution(WipFolder, WipName), Is.EqualTo("// finished"));
    }

    [Test]
    public void Finish_Merge_KeepsStoredFilesAddsNewCasesAndRemovesTheWipFolder()
    {
        var source = CreateFolder(WipFolder, WipName, "// finished");
        var stored = CreateFolder(Bucket, StoredName, "// stored");
        File.WriteAllText(Path.Combine(stored, "TestCase1.json"), FirstTestCase);
        File.WriteAllText(Path.Combine(source, "TestCase1.json"), FirstTestCase);
        File.WriteAllText(Path.Combine(source, "TestCase2.json"), SecondTestCase);

        var exitCode = Finish("m\n", 1);

        Assert.That(exitCode, Is.Zero);
        Assert.That(Directory.Exists(source), Is.False);
        Assert.That(ReadSolution(Bucket, StoredName), Is.EqualTo("// stored"));
        Assert.That(File.ReadAllText(Path.Combine(stored, "Solution1.cs.new")), Is.EqualTo("// finished"));
        Assert.That(File.ReadAllText(Path.Combine(stored, "TestCase2.json")), Is.EqualTo(SecondTestCase));
        Assert.That(_output.ToString(), Does.Contain("merged 1"));
    }

    [Test]
    public void Finish_MergeWithSubfolders_FailsWithoutChangingAnything()
    {
        var source = CreateFolder(WipFolder, WipName, "// finished");
        Directory.CreateDirectory(Path.Combine(source, "Data"));
        CreateFolder(Bucket, StoredName, "// stored");

        var exitCode = Finish("m\n", 1);

        Assert.That(exitCode, Is.EqualTo(1));
        Assert.That(Directory.Exists(source), Is.True);
        Assert.That(ReadSolution(Bucket, StoredName), Is.EqualTo("// stored"));
    }

    [Test]
    public void Finish_OverwriteConfirmed_ShowsTheDiffAndReplacesTheStoredFolder()
    {
        CreateFolder(WipFolder, WipName, "// finished");
        CreateFolder(Bucket, StoredName, "// stored");

        var exitCode = Finish("o\ny\n", 1);

        Assert.That(exitCode, Is.Zero);
        Assert.That(_diffCount, Is.EqualTo(1));
        Assert.That(Directory.GetDirectories(Bucket).Select(Path.GetFileName), Is.EqualTo(new[] { WipName }));
        Assert.That(ReadSolution(Bucket, WipName), Is.EqualTo("// finished"));
        Assert.That(_output.ToString(), Does.Contain("overwritten 1"));
    }

    [Test]
    public void Finish_OverwriteDeclined_KeepsBothFolders()
    {
        CreateFolder(WipFolder, WipName, "// finished");
        CreateFolder(Bucket, StoredName, "// stored");

        Finish("o\nn\n", 1);

        Assert.That(_diffCount, Is.EqualTo(1));
        Assert.That(ReadSolution(Bucket, StoredName), Is.EqualTo("// stored"));
        Assert.That(ReadSolution(WipFolder, WipName), Is.EqualTo("// finished"));
        Assert.That(_output.ToString(), Does.Contain("skipped 1"));
    }

    [Test]
    public void Finish_SeveralStoredFoldersForTheNumber_Fails()
    {
        CreateFolder(WipFolder, WipName, "// finished");
        CreateFolder(Bucket, StoredName, "// stored");
        CreateFolder(Bucket, "0001 Two Numbers", "// other");

        var exitCode = Finish(string.Empty, 1);

        Assert.That(exitCode, Is.EqualTo(1));
        Assert.That(_error.ToString(), Does.Contain("several folders"));
        Assert.That(Directory.Exists(Path.Combine(WipFolder, WipName)), Is.True);
    }

    [Test]
    public void Finish_MissingWipFolder_FailsAndOtherNumbersStillMove()
    {
        CreateFolder(WipFolder, WipName, "// finished");

        var exitCode = Finish(string.Empty, 2, 1);

        Assert.That(exitCode, Is.EqualTo(1));
        Assert.That(_error.ToString(), Does.Contain("0002: FAILED - no !WIP/0002 folder"));
        Assert.That(_output.ToString(), Does.Contain("moved 1, merged 0, overwritten 0, skipped 0, failed 1"));
    }

    private int Finish(string input, params int[] numbers)
    {
        using var reader = new StringReader(input);
        return new ProblemFinisher(_problemsFolder, Directory.Move, (_, _) => _diffCount++, reader, _output, _error).Finish(numbers);
    }

    private static string CreateFolder(string parent, string name, string solution)
    {
        var folder = Path.Combine(parent, name);
        Directory.CreateDirectory(folder);
        File.WriteAllText(Path.Combine(folder, "Solution1.cs"), solution);
        return folder;
    }

    private static string ReadSolution(string parent, string name)
    {
        return File.ReadAllText(Path.Combine(parent, name, "Solution1.cs"));
    }
}
