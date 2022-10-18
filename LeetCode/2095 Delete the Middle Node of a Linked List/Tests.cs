using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._2095_Delete_the_Middle_Node_of_a_Linked_List;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.DeleteMiddle(ListNode.Create(testCase.Values)), Is.EqualTo(ListNode.Create(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Values { get; private init; } = null!;
        public int[] OutputValues { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Values = new[] { 1, 3, 4, 7, 1, 2, 6 },
                    OutputValues = new[] { 1, 3, 4, 1, 2, 6 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Values = new[] { 1, 2, 3, 4 },
                    OutputValues = new[] { 1, 2, 4 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Values = new[] { 2, 1 },
                    OutputValues = new[] { 2 },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}