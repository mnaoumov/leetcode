namespace LeetCode.Problems._1570_Dot_Product_of_Two_Sparse_Vectors;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var v1 = solution.Create(testCase.Nums1);
        var v2 = solution.Create(testCase.Nums2);
        Assert.That(v1.DotProduct(v2), Is.EqualTo(testCase.Output));

    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums1 { get; [UsedImplicitly] init; } = null!;
        public int[] Nums2 { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}

