using System.CommandLine;
using LeetCodeExporter;

namespace LeetCodeExporter.Tests;

public class CommandSetupTests
{
    [Test]
    public void CreateCommand_ParsesProblemOption()
    {
        string? capturedProblemNumber = null;

        var command = CommandSetup.CreateCommand((pn, _) => capturedProblemNumber = pn);
        command.Parse(["--problem", "3508"]).Invoke();

        Assert.That(capturedProblemNumber, Is.EqualTo("3508"));
    }

    [Test]
    public void CreateCommand_ParsesProblemShortAlias()
    {
        string? capturedProblemNumber = null;

        var command = CommandSetup.CreateCommand((pn, _) => capturedProblemNumber = pn);
        command.Parse(["-p", "3508"]).Invoke();

        Assert.That(capturedProblemNumber, Is.EqualTo("3508"));
    }

    [Test]
    public void CreateCommand_DefaultSolutionNumber_IsNull()
    {
        int? capturedSolutionNumber = -1;

        var command = CommandSetup.CreateCommand((_, sn) => capturedSolutionNumber = sn);
        command.Parse(["--problem", "3508"]).Invoke();

        Assert.That(capturedSolutionNumber, Is.Null);
    }

    [Test]
    public void CreateCommand_ParsesSolutionOption()
    {
        int? capturedSolutionNumber = null;

        var command = CommandSetup.CreateCommand((_, sn) => capturedSolutionNumber = sn);
        command.Parse(["--problem", "3508", "--solution", "2"]).Invoke();

        Assert.That(capturedSolutionNumber, Is.EqualTo(2));
    }

    [Test]
    public void CreateCommand_ParsesSolutionShortAlias()
    {
        int? capturedSolutionNumber = null;

        var command = CommandSetup.CreateCommand((_, sn) => capturedSolutionNumber = sn);
        command.Parse(["--problem", "3508", "-s", "3"]).Invoke();

        Assert.That(capturedSolutionNumber, Is.EqualTo(3));
    }

    [Test]
    public void CreateCommand_ReturnsNonZeroExitCode_WhenProblemOptionMissing()
    {
        var command = CommandSetup.CreateCommand((_, _) => { });
        var exitCode = command.Parse([]).Invoke();

        Assert.That(exitCode, Is.Not.EqualTo(0));
    }
}
