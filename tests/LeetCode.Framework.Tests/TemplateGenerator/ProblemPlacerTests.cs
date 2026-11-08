using System.CommandLine;
using TemplateGenerator;

namespace LeetCode.Framework.Tests.TemplateGenerator;

public class ProblemPlacerTests
{
    private const string Title = "1. Two Sum";
    private const string FolderName = "0001 Two Sum";
    private const string Signature = "int[] TwoSum(int[] nums, int target)";
    private const string FirstExample = "\r\nInput: nums = [2,7,11,15], target = 9\r\nOutput: [0,1]\r\n";
    private const string SecondExample = "\r\nInput: nums = [3,2,4], target = 6\r\nOutput: [1,2]\r\n";
    private const string StoredSolution = "// the stored solution\r\n";

    private string _problemsFolder = string.Empty;
    private StringWriter _output = new();

    private string WipFolder => Path.Combine(_problemsFolder, "!WIP");

    [SetUp]
    public void SetUp()
    {
        _problemsFolder = Path.Combine(Path.GetTempPath(), $"ProblemPlacerTests-{Guid.NewGuid():N}");
        Directory.CreateDirectory(_problemsFolder);
        _output = new StringWriter();
    }

    [TearDown]
    public void TearDown()
    {
        _output.Dispose();
        Directory.Delete(_problemsFolder, true);
    }

    [Test]
    public void Place_NewProblem_CreatesWipFolder()
    {
        var folder = Place(CreateGenerator(FirstExample + SecondExample));

        Assert.That(folder, Is.EqualTo(Path.Combine(WipFolder, FolderName)));
        Assert.That(FileNames(folder), Is.EqualTo(new[] { "ISolution.cs", "Solution1.cs", "TestCase1.json", "TestCase2.json", "Tests.cs" }));
        Assert.That(_output.ToString(), Does.Contain("Created !WIP/0001 Two Sum"));
    }

    [Test]
    public void Place_SolvedProblem_MovesItBackIntoWipAndKeepsTheSolution()
    {
        var stored = StoreSolved(FolderName, FirstExample);

        var folder = Place(CreateGenerator(FirstExample));

        Assert.That(Directory.Exists(stored), Is.False);
        Assert.That(folder, Is.EqualTo(Path.Combine(WipFolder, FolderName)));
        Assert.That(File.ReadAllText(Path.Combine(folder, "Solution1.cs")), Is.EqualTo(StoredSolution));
        Assert.That(FileNames(folder), Is.EqualTo(new[] { "ISolution.cs", "Solution1.cs", "TestCase1.json", "Tests.cs" }));
        Assert.That(_output.ToString(), Does.Contain("Moved 00").And.Contain("-> !WIP/0001 Two Sum"));
    }

    [Test]
    public void Place_NewTestCase_IsAddedAfterTheStoredOnes()
    {
        StoreSolved(FolderName, FirstExample);

        var folder = Place(CreateGenerator(FirstExample + SecondExample));

        Assert.That(FileNames(folder).Where(name => name.StartsWith("TestCase")), Is.EqualTo(new[] { "TestCase1.json", "TestCase2.json" }));
        Assert.That(File.ReadAllText(Path.Combine(folder, "TestCase2.json")), Does.Contain("[3, 2, 4]"));
    }

    [Test]
    public void Place_TenthTestCase_PadsTheStoredNumbers()
    {
        var stored = StoreSolved(FolderName, FirstExample);

        for (var i = 2; i <= 9; i++)
        {
            File.WriteAllText(Path.Combine(stored, $"TestCase{i}.json"), $$"""{ "nums": [{{i}}], "target": {{i}}, "output": [0] }""");
        }

        var folder = Place(CreateGenerator(FirstExample + SecondExample));

        var testCases = FileNames(folder).Where(name => name.StartsWith("TestCase")).ToArray();
        Assert.That(testCases, Has.Length.EqualTo(10));
        Assert.That(testCases[0], Is.EqualTo("TestCase01.json"));
        Assert.That(testCases[^1], Is.EqualTo("TestCase10.json"));
    }

    [Test]
    public void Place_ChangedSignature_WritesTheFreshInterfaceBesideTheStoredOne()
    {
        var stored = StoreSolved(FolderName, FirstExample);
        var storedInterfacePath = Path.Combine(stored, "ISolution.cs");
        var storedInterface = File.ReadAllText(storedInterfacePath).Replace("int target", "long target");
        File.WriteAllText(storedInterfacePath, storedInterface);

        var folder = Place(CreateGenerator(FirstExample));

        Assert.That(File.ReadAllText(Path.Combine(folder, "ISolution.cs")), Is.EqualTo(storedInterface));
        Assert.That(File.ReadAllText(Path.Combine(folder, "ISolution.cs" + ProblemPlacer.NewFileSuffix)), Does.Contain("int target"));
        Assert.That(_output.ToString(), Does.Contain("DIFFERS: ISolution.cs"));
    }

    [Test]
    public void Place_RenamedProblem_KeepsTheStoredFolderAndNamespace()
    {
        StoreSolved("0001 Old Name", FirstExample);

        var folder = Place(CreateGenerator(FirstExample));

        Assert.That(folder, Is.EqualTo(Path.Combine(WipFolder, "0001 Old Name")));
        Assert.That(FileNames(folder), Does.Not.Contain("ISolution.cs" + ProblemPlacer.NewFileSuffix));
        Assert.That(_output.ToString(), Does.Contain("Kept the stored folder name '0001 Old Name'"));
    }

    [Test]
    public void Place_ProblemAlreadyInWip_MergesInsteadOfOverwriting()
    {
        var first = Place(CreateGenerator(FirstExample));
        File.WriteAllText(Path.Combine(first, "Solution1.cs"), StoredSolution);

        var second = Place(CreateGenerator(FirstExample + SecondExample));

        Assert.That(second, Is.EqualTo(first));
        Assert.That(File.ReadAllText(Path.Combine(second, "Solution1.cs")), Is.EqualTo(StoredSolution));
        Assert.That(File.Exists(Path.Combine(second, "TestCase2.json")), Is.True);
    }

    [Test]
    public void Place_ProblemInWipAndBucket_UsesTheWipOneAndMovesNothing()
    {
        var bucket = StoreSolved(FolderName, FirstExample);
        var wip = Place(CreateGenerator(FirstExample));

        Assert.That(Directory.Exists(bucket), Is.False);

        StoreSolved(FolderName, FirstExample);
        Place(CreateGenerator(FirstExample));

        Assert.That(Directory.Exists(bucket), Is.True);
        Assert.That(Directory.Exists(wip), Is.True);
    }

    [Test]
    public void TestCasesEqual_IgnoresFormattingAndSchema()
    {
        const string stored = """{ "nums": [1, 2], "output": 3 }""";
        const string fresh = "{\r\n  \"$schema\": \"../../testcase.schema.json\",\r\n  \"nums\": [1,2],\r\n  \"output\": 3\r\n}";

        Assert.That(ProblemPlacer.TestCasesEqual(stored, fresh), Is.True);
        Assert.That(ProblemPlacer.TestCasesEqual(stored, fresh.Replace("3", "4")), Is.False);
    }

    private static CSharpMethodGenerator CreateGenerator(string description)
    {
        var generator = new CSharpMethodGenerator();
        var command = new Command(generator.CommandName);
        generator.ConfigureCommand(command);
        generator.SetOptions(command.Parse(["--title", Title, "--method-signature", Signature, "--description", description]));
        return generator;
    }

    private string Place(CSharpMethodGenerator generator) =>
        new ProblemPlacer(_problemsFolder, Directory.Move, _output).Place(generator);

    /// <summary>
    /// A solved problem in its bucket, as the generator rendered it for that folder name, with a written solution.
    /// </summary>
    private string StoreSolved(string folderName, string description)
    {
        var generator = CreateGenerator(description);
        generator.UseFolderName(folderName);
        generator.Generate();
        var folder = Path.Combine(_problemsFolder, folderName[..2], folderName);
        Directory.CreateDirectory(folder);

        foreach (var file in generator.Files)
        {
            File.WriteAllText(Path.Combine(folder, file.Name), file.Content);
        }

        File.WriteAllText(Path.Combine(folder, "Solution1.cs"), StoredSolution);
        return folder;
    }

    private static string[] FileNames(string folder) =>
        Directory.GetFiles(folder).Select(Path.GetFileName).OfType<string>().Order(StringComparer.Ordinal).ToArray();
}
