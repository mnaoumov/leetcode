using JetBrains.Annotations;

namespace LeetCode._1125_Smallest_Sufficient_Team;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.SmallestSufficientTeam(testCase.Req_skills, testCase.People), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        // ReSharper disable once InconsistentNaming
        public string[] Req_skills { get; [UsedImplicitly] init; } = null!;
        public IList<IList<string>> People { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
