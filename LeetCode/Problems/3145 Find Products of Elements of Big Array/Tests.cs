using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._3145_Find_Products_of_Elements_of_Big_Array;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindProductsOfElements(testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public long[][] Queries { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
