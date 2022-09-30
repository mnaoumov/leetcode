using NUnit.Framework;

namespace LeetCode._027_Remove_Element;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        int k = solution.RemoveElement(testCase.Nums, testCase.Val);

        Assert.That(k, Is.EqualTo(testCase.ExpectedNums.Length));
        Assert.That(testCase.Nums.Take(k).OrderBy(x => x), Is.EqualTo(testCase.ExpectedNums));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int Val { get; private init; }
        public int[] ExpectedNums { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 3, 2, 2, 3 },
                    Val = 3,
                    ExpectedNums = new[] { 2, 2 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 0, 1, 2, 2, 3, 0, 4, 2 },
                    Val = 2,
                    ExpectedNums = new[] { 0, 0, 1, 3, 4 },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
