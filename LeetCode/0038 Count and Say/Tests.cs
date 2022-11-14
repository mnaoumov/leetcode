using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0038_Count_and_Say;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountAndSay(testCase.N), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; [UsedImplicitly] init; }
        public string Output { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    N = 1,
                    Output = "1",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    N = 4,
                    Output = "1211",
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}