
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2559_Count_Vowel_Strings_in_Ranges;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.VowelStrings(testCase.Words, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string[] Words { get; [UsedImplicitly] init; } = null!;
        public int[][] Queries { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
