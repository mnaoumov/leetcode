using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0129_Sum_Root_to_Leaf_Numbers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SumNumbers(TreeNode.Create(testCase.RootValues)!), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] RootValues { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    RootValues = new int?[] { 1, 2, 3 },
                    Output = 25,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    RootValues = new int?[] { 4, 9, 0, 5, 1 },
                    Output = 1026,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
