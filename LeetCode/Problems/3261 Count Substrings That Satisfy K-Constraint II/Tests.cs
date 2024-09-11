using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._3261_Count_Substrings_That_Satisfy_K_Constraint_II;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.CountKConstraintSubstrings(testCase.S, testCase.K, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int[][] Queries { get; [UsedImplicitly] init; } = null!;
        public long[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
