using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._6233_Convert_the_Temperature;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ConvertTemperature(testCase.Celsius), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public double Celsius { get; [UsedImplicitly] init; }
        public double[] Output { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Celsius = 36.5,
                    Output = new[] { 309.65, 97.7 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Celsius = 122.11,
                    Output = new[] { 395.26, 251.798 },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
