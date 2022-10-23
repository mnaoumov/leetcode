using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0092_Reverse_Linked_List_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ReverseBetween(ListNode.Create(testCase.Values), testCase.Left, testCase.Right), Is.EqualTo(ListNode.Create(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Values { get; private init; } = null!;
        public int Left { get; private init; }
        public int Right { get; private init; }
        public int[] OutputValues { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Values = new[] { 1, 2, 3, 4, 5 },
                    Left = 2,
                    Right = 4,
                    OutputValues = new[] { 1, 4, 3, 2, 5 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Values = new[] { 5 },
                    Left = 1,
                    Right = 1,
                    OutputValues = new[] { 5 },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}