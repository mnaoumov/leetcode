using NUnit.Framework;

namespace LeetCode._0621_Task_Scheduler;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LeastInterval(testCase.Tasks, testCase.N), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public char[] Tasks { get; private init; } = null!;
        public int N { get; private init; }
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Tasks = new[] { 'A', 'A', 'A', 'B', 'B', 'B' },
                    N = 2,
                    Output = 8,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Tasks = new[] { 'A', 'A', 'A', 'B', 'B', 'B' },
                    N = 0,
                    Output = 6,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Tasks = new[] { 'A', 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G' },
                    N = 2,
                    Output = 16,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    Tasks = new[] { 'A', 'A', 'A', 'B', 'B', 'B' },
                    N = 50,
                    Output = 104,
                    TestCaseName = nameof(Solution1)
                };
                
                yield return new TestCase
                {
                    Tasks = new[] { 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                    N = 29,
                    Output = 31,
                    TestCaseName = nameof(Solution5_8)
                };
            }
        }
    }
}