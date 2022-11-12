using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2466_Count_Ways_To_Build_Good_Strings;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountGoodStrings(testCase.Low, testCase.High, testCase.Zero, testCase.One), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int Low { get; private init; }
        public int High { get; private init; }
        public int Zero { get; private init; }
        public int One { get; private init; }
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Low = 3,
                    High = 3,
                    Zero = 1,
                    One = 1,
                    Output = 8,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Low = 2,
                    High = 3,
                    Zero = 1,
                    One = 2,
                    Output = 5,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Low = 200,
                    High = 200,
                    Zero = 10,
                    One = 1,
                    Output = 764262396,
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}
