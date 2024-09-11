using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;
using NUnit.Framework;

namespace LeetCode.Problems._1602_Find_Nearest_Right_Node_in_Binary_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var root = TreeNode.Create(testCase.Root);
        var u = root.FindNode(testCase.U)!;
        var output = testCase.Output == null ? null : root.FindNode(testCase.Output.Value);
        Assert.That(solution.FindNearestRightNode(root, u), Is.EqualTo(output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int U { get; [UsedImplicitly] init; }
        public int? Output { get; [UsedImplicitly] init; } = null!;
    }
}
