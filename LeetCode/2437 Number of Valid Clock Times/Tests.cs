using NUnit.Framework;

namespace LeetCode._2437_Number_of_Valid_Clock_Times;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountTime(testCase.Time), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string Time { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Time = "?5:00",
                    Output = 2,
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    Time = "0?:0?",
                    Output = 100,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Time = "??:??",
                    Output = 1440,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}