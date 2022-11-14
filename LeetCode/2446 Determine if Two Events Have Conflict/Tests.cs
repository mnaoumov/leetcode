using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2446_Determine_if_Two_Events_Have_Conflict;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.HaveConflict(testCase.Event1, testCase.Event2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string[] Event1 { get; [UsedImplicitly] init; } = null!;
        public string[] Event2 { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Event1 = new[] { "01:15", "02:00" },
                    Event2 = new[] { "02:00", "03:00" },
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Event1 = new[] { "01:00", "02:00" },
                    Event2 = new[] { "01:20", "03:00" },
                    Output = true,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Event1 = new[] { "01:00", "02:00" },
                    Event2 = new[] { "14:00", "15:00" },
                    Output = false,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}