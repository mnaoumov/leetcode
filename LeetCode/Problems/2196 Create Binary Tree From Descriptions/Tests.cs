using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;
using NUnit.Framework;

namespace LeetCode.Problems._2196_Create_Binary_Tree_From_Descriptions;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CreateBinaryTree(testCase.Descriptions), Is.EqualTo(TreeNode.CreateOrNull(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Descriptions { get; [UsedImplicitly] init; } = null!;
        public int?[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
