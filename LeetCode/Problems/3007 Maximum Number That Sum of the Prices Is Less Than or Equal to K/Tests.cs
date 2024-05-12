using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._3007_Maximum_Number_That_Sum_of_the_Prices_Is_Less_Than_or_Equal_to_K;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindMaximumNumber(testCase.K, testCase.X), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public long K { get; [UsedImplicitly] init; }
        public int X { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
