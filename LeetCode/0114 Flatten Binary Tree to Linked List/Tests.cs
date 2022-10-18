using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0114_Flatten_Binary_Tree_to_Linked_List;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var root = TreeNode.Create(testCase.Values)!;
        solution.Flatten(root);
        Assert.That(root, Is.EqualTo(TreeNode.Create(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] Values { get; private init; } = null!;
        public int?[] OutputValues { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Values = new int?[] { 1, 2, 5, 3, 4, null, 6 },
                    OutputValues = new int?[] { 1, null, 2, null, 3, null, 4, null, 5, null, 6 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Values = Array.Empty<int?>(),
                    OutputValues = Array.Empty<int?>(),
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Values = new int?[] { 0 },
                    OutputValues = new int?[] { 0 },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}