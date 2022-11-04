using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._2443_Sum_of_Number_and_Its_Reverse;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SumOfNumberAndReverse(testCase.Num), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int Num { get; private init; }
        public bool Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Num = 443,
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Num = 63,
                    Output = false,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Num = 181,
                    Output = true,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    Num = 0,
                    Output = true,
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}