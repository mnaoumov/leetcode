using NUnit.Framework;

namespace LeetCode._035_Search_Insert_Position;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SearchInsert(testCase.Nums, testCase.Target), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int Target { get; private init; }
        public int Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 1, 3, 5, 6 },
                    Target = 5,
                    Return = 2,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 3, 5, 6 },
                    Target = 2,
                    Return = 1,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 3, 5, 6 },
                    Target = 7,
                    Return = 4,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}