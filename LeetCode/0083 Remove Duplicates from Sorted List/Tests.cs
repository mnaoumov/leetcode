using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0083_Remove_Duplicates_from_Sorted_List;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.DeleteDuplicates(ListNode.CreateOrNull(testCase.Values)), Is.EqualTo(ListNode.CreateOrNull(testCase.OutputValues)));
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
                    Values = new[] { 1, 1, 2 },
                    OutputValues = new[] { 1, 2 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Values = new[] { 1, 1, 2, 3, 3 },
                    OutputValues = new[] { 1, 2, 3 },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}