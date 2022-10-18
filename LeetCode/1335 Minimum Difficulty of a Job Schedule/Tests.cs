using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._1335_Minimum_Difficulty_of_a_Job_Schedule;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinDifficulty(testCase.JobDifficulty, testCase.D), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] JobDifficulty { get; private init; } = null!;
        public int D { get; private init; }
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    JobDifficulty = new[] { 6, 5, 4, 3, 2, 1 },
                    D = 2,
                    Output = 7,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    JobDifficulty = new[] { 9, 9, 9 },
                    D = 4,
                    Output = -1,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    JobDifficulty = new[] { 1, 1, 1 },
                    D = 3,
                    Output = 3,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}