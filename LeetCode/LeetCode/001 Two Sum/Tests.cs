using NUnit.Framework;

namespace LeetCode._001_Two_Sum;

[TestFixture]
public class Tests : TestsBase2<ISolution, (int[] nums, int target, int[] expectedResult), Tests.TestCaseBuilder>
{
    protected override void TestImpl(ISolution solution, (int[] nums, int target, int[] expectedResult) testCase)
    {
        Assert.That(solution.TwoSum(testCase.nums, testCase.target), Is.EqualTo(testCase.expectedResult));
    }

    public class TestCaseBuilder : TestCaseBuilderBase<(int[] nums, int target, int[] expectedResult)>
    {
        public override IEnumerable<((int[] nums, int target, int[] expectedResult) testCase, string testCaseName)> TestCasesWithNames
        {
            get
            {
                yield return (testCase: (nums: new[] { 2, 7, 11, 15 }, target: 9, expectedResult: new[] { 0, 1 }), testCaseName: "Example 1");
                yield return (testCase: (nums: new[] { 3, 2, 4, 6 }, target: 6, expectedResult: new[] { 1, 2 }), testCaseName: "Example 2");
                yield return (testCase: (nums: new[] { 3, 3 }, target: 6, expectedResult: new[] { 0, 1 }), testCaseName: "Example 3");
            }
        }
    }
}