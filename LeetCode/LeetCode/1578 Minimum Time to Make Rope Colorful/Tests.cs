using NUnit.Framework;

namespace LeetCode._1578_Minimum_Time_to_Make_Rope_Colorful;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinCost(testCase.Colors, testCase.NeededTime), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string Colors { get; private init; } = null!;
        public int[] NeededTime { get; private init; } = null!;
        public int Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Colors = "abaac",
                    NeededTime = new[] { 1, 2, 3, 4, 5 },
                    Return = 3,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Colors = "abc",
                    NeededTime = new[] { 1, 2, 3 },
                    Return = 0,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Colors = "aabaa",
                    NeededTime = new[] { 1, 2, 3, 4, 1 },
                    Return = 2,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}