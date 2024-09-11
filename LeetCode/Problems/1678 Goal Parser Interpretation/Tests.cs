using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1678_Goal_Parser_Interpretation;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Interpret(testCase.Command), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Command { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
