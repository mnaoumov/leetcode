using NUnit.Framework;

namespace LeetCode._0421_Maximum_XOR_of_Two_Numbers_in_an_Array;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindMaximumXOR(testCase.Nums), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int Output { get; private init; }


        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 3, 10, 5, 25, 2, 8 },
                    Output = 28,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 14, 70, 53, 83, 49, 91, 36, 80, 92, 51, 66, 70 },
                    Output = 127,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}