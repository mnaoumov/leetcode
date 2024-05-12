using JetBrains.Annotations;

namespace LeetCode.Problems._2092_Find_All_People_With_Secret;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.FindAllPeople(testCase.N, testCase.Meetings, testCase.FirstPerson), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Meetings { get; [UsedImplicitly] init; } = null!;
        public int FirstPerson { get; [UsedImplicitly] init; }
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
