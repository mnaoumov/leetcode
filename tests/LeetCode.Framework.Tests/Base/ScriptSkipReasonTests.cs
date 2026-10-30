using LeetCode.Base;

namespace LeetCode.Framework.Tests.Base;

public class ScriptSkipReasonTests
{
    [TestCase("-- https://leetcode.com/submissions/detail/1/")]
    [TestCase("")]
    [TestCase("# SkipSolution: WrongAnswer")]
    public void LineWithoutMarker_SkipsNothing(string firstLine)
    {
        var parsed = TestsBase.TryReadScriptSkipReason(firstLine, "--", out var reason, out var error);

        Assert.Multiple(() =>
        {
            Assert.That(parsed, Is.True);
            Assert.That(reason, Is.Null);
            Assert.That(error, Is.Null);
        });
    }

    [TestCase("--", "-- SkipSolution: WrongAnswer", "WrongAnswer")]
    [TestCase("#", "# SkipSolution: RuntimeError", "RuntimeError")]
    [TestCase("//", "// SkipSolution: TimeLimitExceeded ", "TimeLimitExceeded")]
    public void Marker_NamesItsReason(string lineComment, string firstLine, string expected)
    {
        var parsed = TestsBase.TryReadScriptSkipReason(firstLine, lineComment, out var reason, out _);

        Assert.Multiple(() =>
        {
            Assert.That(parsed, Is.True);
            Assert.That(reason.ToString(), Is.EqualTo(expected));
        });
    }

    // The C# attribute takes the same enum, so a script cannot skip for a reason a C# solution could not give.
    [TestCase("-- SkipSolution: Wrong answer")]
    [TestCase("-- SkipSolution: wronganswer")]
    [TestCase("-- SkipSolution: 1")]
    [TestCase("-- SkipSolution:")]
    public void MarkerWithUnknownReason_IsAnError(string firstLine)
    {
        var parsed = TestsBase.TryReadScriptSkipReason(firstLine, "--", out var reason, out var error);

        Assert.Multiple(() =>
        {
            Assert.That(parsed, Is.False);
            Assert.That(reason, Is.Null);
            Assert.That(error, Does.Contain("unknown reason").And.Contain(nameof(SkipSolutionReason.WrongAnswer)));
        });
    }
}
