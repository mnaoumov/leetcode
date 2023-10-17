using JetBrains.Annotations;

namespace LeetCode._2899_Last_Visited_Integers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.LastVisitedIntegers(testCase.Words), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public IList<string> Words { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
