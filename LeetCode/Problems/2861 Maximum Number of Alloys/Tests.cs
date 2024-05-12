using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._2861_Maximum_Number_of_Alloys;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxNumberOfAlloys(testCase.N, testCase.K, testCase.Budget, testCase.Composition, testCase.Stock, testCase.Cost), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public int Budget { get; [UsedImplicitly] init; }
        public IList<IList<int>> Composition { get; [UsedImplicitly] init; } = null!;
        public IList<int> Stock { get; [UsedImplicitly] init; } = null!;
        public IList<int> Cost { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
