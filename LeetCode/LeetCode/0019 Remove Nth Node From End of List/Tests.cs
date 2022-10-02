using NUnit.Framework;

namespace LeetCode._0019_Remove_Nth_Node_From_End_of_List;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.RemoveNthFromEnd(ListNode.Create(testCase.HeadValues), testCase.N),
            Is.EqualTo(ListNode.CreateOrNull(testCase.ReturnValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] HeadValues { get; private init; } = null!;
        public int N { get; private init; }
        public int[] ReturnValues { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    HeadValues = new[] { 1, 2, 3, 4, 5 },
                    N = 2,
                    ReturnValues = new[] { 1, 2, 3, 5 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    HeadValues = new[] { 1 },
                    N = 1,
                    ReturnValues = Array.Empty<int>(),
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    HeadValues = new[] { 1, 2 },
                    N = 1,
                    ReturnValues = new[] { 1 },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
