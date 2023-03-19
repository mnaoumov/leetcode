using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0114_Flatten_Binary_Tree_to_Linked_List;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var root = TreeNode.CreateOrNull(testCase.Values);
        solution.Flatten(root);
        Assert.That(root, Is.EqualTo(TreeNode.CreateOrNull(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Values { get; [UsedImplicitly] init; } = null!;
        public int?[] OutputValues { get; [UsedImplicitly] init; } = null!;
    }
}