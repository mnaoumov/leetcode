﻿using JetBrains.Annotations;

namespace LeetCode._0047_Permutations_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.PermuteUnique(testCase.Nums), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;
    }
}