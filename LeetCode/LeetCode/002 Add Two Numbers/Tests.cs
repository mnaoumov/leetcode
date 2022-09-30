using NUnit.Framework;

namespace LeetCode._002_Add_Two_Numbers;

public class Tests : TestsBase2<ISolution, (int[] list1Values, int[] list2Values, int[] expectedResultValues), Tests.TestCaseBuilder>
{
    protected override void TestImpl(ISolution solution, (int[] list1Values, int[] list2Values, int[] expectedResultValues) testCase)
    {
        var list1 = ListNode.Create(testCase.list1Values);
        var list2 = ListNode.Create(testCase.list2Values);
        var expectedResult = ListNode.Create(testCase.expectedResultValues);
        Assert.That(solution.AddTwoNumbers(list1, list2), Is.EqualTo(expectedResult));
    }

    public class TestCaseBuilder : TestCaseBuilderBase<(int[] list1Values, int[] list2Values, int[] expectedResultValues)>
    {
        public override IEnumerable<((int[] list1Values, int[] list2Values, int[] expectedResultValues) testCase, string testCaseName)> TestCasesWithNames
        {
            get
            {
                yield return (
                    testCase: (list1Values: new[] { 2, 4, 3 }, list2Values: new[] { 5, 6, 4 },
                        expectedResultValues: new[] { 7, 0, 8 }), testCaseName: "Example 1");
                yield return (
                    testCase: (list1Values: new[] { 0 }, list2Values: new[] { 0 },
                        expectedResultValues: new[] { 0 }), testCaseName: "Example 2");
                yield return (
                    testCase: (list1Values: new[] { 9, 9, 9, 9, 9, 9, 9 }, list2Values: new[] { 9, 9, 9, 9 },
                        expectedResultValues: new[] { 8, 9, 9, 9, 0, 0, 0, 1 }), testCaseName: "Example 3");
            }
        }
    }
}