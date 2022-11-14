using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0142_Linked_List_Cycle_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var root = ListNode.CreateOrNull(testCase.Values);
        var tail = root;
        ListNode? cycleStartNode = null;

        if (tail != null)
        {
            while (tail.next != null)
            {
                tail = tail.next;
            }

            if (testCase.Pos == -1)
            {
                cycleStartNode = null;
            }
            else
            {
                cycleStartNode = root;

                for (var i = 1; i < testCase.Pos; i++)
                {
                    cycleStartNode = cycleStartNode!.next;
                }
            }

            tail.next = cycleStartNode;
        }

        Assert.That(solution.DetectCycle(root), Is.SameAs(cycleStartNode));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Values { get; [UsedImplicitly] init; } = null!;
        public int Pos { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Values = new[] { 3, 2, 0, -4 },
                    Pos = 1,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Values = new[] { 1, 2 },
                    Pos = 0,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Values = new[] { 1 },
                    Pos = -1,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    Values = Array.Empty<int>(),
                    Pos = -1,
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}