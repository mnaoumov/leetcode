using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0100_Same_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsSameTree(TreeNode.Create(testCase.PValues)!, TreeNode.Create(testCase.QValues)!), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] PValues { get; private init; } = null!;
        public int?[] QValues { get; private init; } = null!;
        public bool Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    PValues = new int?[] { 1, 2, 3 },
                    QValues = new int?[] { 1, 2, 3 },
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    PValues = new int?[] { 1, 2 },
                    QValues = new int?[] { 1, null, 2 },
                    Output = false,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    PValues = new int?[] { 1, 2, 1 },
                    QValues = new int?[] { 1, 1, 2 },
                    Output = false,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}