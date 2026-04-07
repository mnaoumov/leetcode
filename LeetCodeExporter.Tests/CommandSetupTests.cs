using System.CommandLine;
using LeetCodeExporter;

namespace LeetCodeExporter.Tests;

public class CommandSetupTests
{
    [Test]
    public void CreateCommand_ParsesProblemNumberArgument()
    {
        string? capturedProblemNumber = null;

        var command = CommandSetup.CreateCommand((pn, _) => capturedProblemNumber = pn);
        command.Invoke(["3508"]);

        Assert.That(capturedProblemNumber, Is.EqualTo("3508"));
    }

    [Test]
    public void CreateCommand_DefaultSolutionNumber_IsNull()
    {
        int? capturedSolutionNumber = -1;

        var command = CommandSetup.CreateCommand((_, sn) => capturedSolutionNumber = sn);
        command.Invoke(["3508"]);

        Assert.That(capturedSolutionNumber, Is.Null);
    }

    [Test]
    public void CreateCommand_ParsesSolutionOption()
    {
        int? capturedSolutionNumber = null;

        var command = CommandSetup.CreateCommand((_, sn) => capturedSolutionNumber = sn);
        command.Invoke(["3508", "--solution", "2"]);

        Assert.That(capturedSolutionNumber, Is.EqualTo(2));
    }

    [Test]
    public void CreateCommand_ParsesSolutionShortAlias()
    {
        int? capturedSolutionNumber = null;

        var command = CommandSetup.CreateCommand((_, sn) => capturedSolutionNumber = sn);
        command.Invoke(["3508", "-s", "3"]);

        Assert.That(capturedSolutionNumber, Is.EqualTo(3));
    }

    [Test]
    public void CreateCommand_ReturnsNonZeroExitCode_WhenProblemNumberMissing()
    {
        var command = CommandSetup.CreateCommand((_, _) => { });
        var exitCode = command.Invoke([]);

        Assert.That(exitCode, Is.Not.EqualTo(0));
    }
}
