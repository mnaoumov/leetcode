using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3093_Longest_Common_Suffix_Queries;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.StringIndices(testCase.WordsContainer, testCase.WordsQuery), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string[] WordsContainer { get; [UsedImplicitly] init; } = null!;
        public string[] WordsQuery { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
