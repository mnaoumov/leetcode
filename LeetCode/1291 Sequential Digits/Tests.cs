using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._1291_Sequential_Digits;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.SequentialDigits(testCase.Low, testCase.High), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int Low { get; [UsedImplicitly] init; }
        public int High { get; [UsedImplicitly] init; }
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
