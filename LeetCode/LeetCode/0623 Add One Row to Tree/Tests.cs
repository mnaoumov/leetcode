using NUnit.Framework;

namespace LeetCode._0623_Add_One_Row_to_Tree;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.AddOneRow(TreeNode.Create(testCase.ValuesBefore)!, testCase.Val, testCase.Depth),
            Is.EqualTo(TreeNode.Create(testCase.ValuesAfter)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int?[] ValuesBefore { get; private init; } = null!;
        public int?[] ValuesAfter { get; private init; } = null!;
        public int Val { get; private init; }
        public int Depth { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    ValuesBefore = new int?[] { 4, 2, 6, 3, 1, 5 },
                    Val = 1,
                    Depth = 2,
                    ValuesAfter = new int?[] { 4, 1, 1, 2, null, null, 6, 3, 1, 5 },
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    ValuesBefore = new int?[] { 4, 2, null, 3, 1 },
                    Val = 1,
                    Depth = 3,
                    ValuesAfter = new int?[] { 4, 2, null, 1, 1, 3, null, null, 1 },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}