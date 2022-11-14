using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0108_Convert_Sorted_Array_to_Binary_Search_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var output = solution.SortedArrayToBST(testCase.Nums);

        var values = GetValues(output);

        AssertCollectionEquivalentWithDetails(values, testCase.Nums);

        var heightDict = new Dictionary<TreeNode, int>();

        AssertHeightBalanced(output);

        void AssertHeightBalanced(TreeNode? node)
        {
            while (true)
            {
                if (node == null)
                {
                    return;
                }

                Assert.That(GetHeight(node.left), Is.EqualTo(GetHeight(node.right)).Within(1));

                AssertHeightBalanced(node.left);
                node = node.right;
            }
        }

        int GetHeight(TreeNode? node)
        {
            if (node == null)
            {
                return 0;
            }

            if (!heightDict.TryGetValue(node, out var height))
            {
                heightDict[node] = height = Calculate();
            }

            return height;

            int Calculate() => 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
        }
    }

    private static IEnumerable<int> GetValues(TreeNode? node)
    {
        if (node == null)
        {
            yield break;
        }

        yield return node.val;

        foreach (var value in GetValues(node.left).Concat(GetValues(node.right)))
        {
            yield return value;
        }
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { -10, -3, 0, 5, 9 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 3 },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}