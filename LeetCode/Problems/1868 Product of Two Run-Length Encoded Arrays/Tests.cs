using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1868_Product_of_Two_Run_Length_Encoded_Arrays;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindRLEArray(testCase.Encoded1, testCase.Encoded2), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Encoded1 { get; [UsedImplicitly] init; } = null!;
        public int[][] Encoded2 { get; [UsedImplicitly] init; } = null!;
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
