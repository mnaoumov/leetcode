using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0141_Linked_List_Cycle;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var head = ListNode.Create(testCase.HeadValues);

        if (testCase.Pos >= 0)
        {
            var posNode = head;

            for (var i = 0; i < testCase.Pos; i++)
            {
                posNode = posNode.next!;
            }

            var tail = posNode;

            while (tail.next != null)
            {
                tail = tail.next;
            }

            tail.next = posNode;
        }

        Assert.That(solution.HasCycle(head), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] HeadValues { get; [UsedImplicitly] init; } = null!;
        public int Pos { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    HeadValues = new[] { 3, 2, 0, -4 },
                    Pos = 1,
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    HeadValues = new[] { 1, 2 },
                    Pos = 0,
                    Output = true,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    HeadValues = new[] { 1 },
                    Pos = -1,
                    Output = false,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
