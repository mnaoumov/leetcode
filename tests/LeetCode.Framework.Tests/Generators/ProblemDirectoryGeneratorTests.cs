using LeetCode.Problems.Generators;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;

namespace LeetCode.Framework.Tests.Generators;

public class ProblemDirectoryGeneratorTests
{
    private const string ProjectDirectory = "/repo/src/LeetCode.Problems";

    [Test]
    public void EachProblemNamespace_IsRecordedWithItsFolder()
    {
        var (source, diagnostics) = Run(
            ("namespace LeetCode.Problems._0001_Two_Sum;\nclass Tests;", "00/0001 Two Sum/Tests.cs"),
            ("namespace LeetCode.Problems._0001_Two_Sum;\ninterface ISolution;", "00/0001 Two Sum/ISolution.cs"),
            ("namespace LeetCode.Problems.A_B_C;\nclass Tests;", "!Unnumbered/A.B C+D! It’s/Tests.cs"));

        Assert.Multiple(() =>
        {
            Assert.That(diagnostics, Is.Empty);
            Assert.That(source, Does.Contain(
                "[assembly: global::LeetCode.Base.ProblemDirectory(\"LeetCode.Problems._0001_Two_Sum\", \"00/0001 Two Sum\")]"));
            Assert.That(source, Does.Contain(
                "[assembly: global::LeetCode.Base.ProblemDirectory(\"LeetCode.Problems.A_B_C\", \"!Unnumbered/A.B C+D! It’s\")]"));
            Assert.That(source.Split("ProblemDirectory(").Length - 1, Is.EqualTo(2));
        });
    }

    [Test]
    public void NamespaceOutsideTheProblems_IsNotRecorded()
    {
        var (source, _) = Run(("namespace LeetCode.Helpers;\nclass Helper;", "Helpers/Helper.cs"));

        Assert.That(source, Does.Not.Contain("ProblemDirectory("));
    }

    [Test]
    public void NamespaceInTwoFolders_IsACompileError()
    {
        var (_, diagnostics) = Run(
            ("namespace LeetCode.Problems._0001_Two_Sum;\nclass Tests;", "00/0001 Two Sum/Tests.cs"),
            ("namespace LeetCode.Problems._0001_Two_Sum;\nclass Tests2;", "!WIP/0001 Two Sum/Tests.cs"));

        Assert.That(diagnostics.Select(diagnostic => (diagnostic.Id, diagnostic.Severity)),
            Is.EqualTo(new[] { ("LC0001", DiagnosticSeverity.Error) }));
    }

    private static (string Source, IReadOnlyList<Diagnostic> Diagnostics) Run(
        params (string Text, string RelativePath)[] files)
    {
        var compilation = CSharpCompilation.Create("LeetCode.Problems",
            files.Select(file => CSharpSyntaxTree.ParseText(file.Text,
                path: $"{ProjectDirectory}/{file.RelativePath}")));
        var driver = CSharpGeneratorDriver.Create(
            [new ProblemDirectoryGenerator().AsSourceGenerator()],
            optionsProvider: new ProjectDirectoryOptionsProvider());

        var result = driver.RunGenerators(compilation).GetRunResult().Results.Single();
        return (result.GeneratedSources.Single().SourceText.ToString(), result.Diagnostics);
    }

    private sealed class ProjectDirectoryOptionsProvider : AnalyzerConfigOptionsProvider
    {
        public override AnalyzerConfigOptions GlobalOptions { get; } = new Options();

        public override AnalyzerConfigOptions GetOptions(SyntaxTree tree) => GlobalOptions;

        public override AnalyzerConfigOptions GetOptions(AdditionalText textFile) => GlobalOptions;

        private sealed class Options : AnalyzerConfigOptions
        {
            public override bool TryGetValue(string key, out string value)
            {
                value = key == "build_property.MSBuildProjectDirectory" ? ProjectDirectory : "";
                return value.Length > 0;
            }
        }
    }
}
