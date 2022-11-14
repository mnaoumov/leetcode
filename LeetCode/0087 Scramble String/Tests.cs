using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0087_Scramble_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsScramble(testCase.S1, testCase.S2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S1 { get; [UsedImplicitly] init; } = null!;
        public string S2 { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}