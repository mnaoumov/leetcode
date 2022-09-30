using NUnit.Framework;

namespace LeetCode._002_Add_Two_Numbers;

public class Tests : TestsBase2<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var list1 = ListNode.Create(testCase.List1Values);
        var list2 = ListNode.Create(testCase.List2Values);
        var Return = ListNode.Create(testCase.ReturnValues);
        Assert.That(solution.AddTwoNumbers(list1, list2), Is.EqualTo(Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] List1Values { get; private init; } = null!;
        public int[] List2Values { get; private init; } = null!;
        public int[] ReturnValues { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    List1Values = new[] { 2, 4, 3 },
                    List2Values = new[] { 5, 6, 4 },
                    ReturnValues = new[] { 7, 0, 8 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    List1Values = new[] { 0 },
                    List2Values = new[] { 0 },
                    ReturnValues = new[] { 0 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    List1Values = new[] { 9, 9, 9, 9, 9, 9, 9 },
                    List2Values = new[] { 9, 9, 9, 9 },
                    ReturnValues = new[] { 8, 9, 9, 9, 0, 0, 0, 1 },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}