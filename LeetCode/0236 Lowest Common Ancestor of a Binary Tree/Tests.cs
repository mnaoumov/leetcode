using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0236_Lowest_Common_Ancestor_of_a_Binary_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var root = TreeNode.Create(testCase.Values);
        var p = root.FindNode(testCase.P)!;
        var q = root.FindNode(testCase.Q)!;
        var returnNode = root.FindNode(testCase.Output)!;
        Assert.That(solution.LowestCommonAncestor(root, p, q), Is.SameAs(returnNode));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Values { get; [UsedImplicitly] init; } = null!;
        public int P { get; [UsedImplicitly] init; }
        public int Q { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }

    }
}
