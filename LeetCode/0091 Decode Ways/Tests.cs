using NUnit.Framework;

namespace LeetCode._0091_Decode_Ways;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumDecodings(testCase.S), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public int Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "12",
                    Return = 2,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "226",
                    Return = 3,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}