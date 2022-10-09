using NUnit.Framework;

namespace LeetCode._0038_Count_and_Say;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountAndSay(testCase.N), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; private init; }
        public string Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    N = 1,
                    Return = "1",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    N = 4,
                    Return = "1211",
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}