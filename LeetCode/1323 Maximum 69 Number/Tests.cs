using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._1323_Maximum_69_Number;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Maximum69Number(testCase.Num), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Num { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}