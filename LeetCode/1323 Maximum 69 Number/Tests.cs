using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._1323_Maximum_69_Number;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Maximum69Number(testCase.Num), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int Num { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Num = 9669,
                    Output = 9969,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Num = 9996,
                    Output = 9999,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Num = 9999,
                    Output = 9999,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
