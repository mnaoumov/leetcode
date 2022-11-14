using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0019_Remove_Nth_Node_From_End_of_List;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.RemoveNthFromEnd(ListNode.Create(testCase.HeadValues), testCase.N),
            Is.EqualTo(ListNode.CreateOrNull(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] HeadValues { get; [UsedImplicitly] init; } = null!;
        public int N { get; [UsedImplicitly] init; }
        public int[] OutputValues { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    HeadValues = new[] { 1, 2, 3, 4, 5 },
                    N = 2,
                    OutputValues = new[] { 1, 2, 3, 5 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    HeadValues = new[] { 1 },
                    N = 1,
                    OutputValues = Array.Empty<int>(),
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    HeadValues = new[] { 1, 2 },
                    N = 1,
                    OutputValues = new[] { 1 },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
