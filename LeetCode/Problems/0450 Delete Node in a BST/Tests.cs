namespace LeetCode.Problems._0450_Delete_Node_in_a_BST;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var result = solution.DeleteNode(TreeNode.CreateOrNull(testCase.Root), testCase.Key);
        var originalNumbers = testCase.Root.OfType<int>().ToArray();
        var numbersAfterRemoval = new List<int>();

        Dfs(result);

        AssertCollectionEquivalentWithDetails(numbersAfterRemoval, originalNumbers.Except(new[] { testCase.Key }));
        AssertValidBst(result);
        return;

        void Dfs(TreeNode? node)
        {
            while (node != null)
            {
                numbersAfterRemoval.Add(node.val);
                Dfs(node.left);
                node = node.right;
            }
        }
    }

    private static void AssertValidBst(TreeNode? root)
    {
        while (root != null)
        {
            if (root.left != null && root.val <= root.left.val)
            {
                Assert.Fail($"Not valid BST. {root.val} value cannot be less than {root.left.val} value");
            }

            if (root.right != null && root.val >= root.right.val)
            {
                Assert.Fail($"Not valid BST. {root.val} value cannot be greater than {root.right.val} value");
            }

            AssertValidBst(root.left);
            root = root.right;
        }
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int Key { get; [UsedImplicitly] init; }
    }
}
