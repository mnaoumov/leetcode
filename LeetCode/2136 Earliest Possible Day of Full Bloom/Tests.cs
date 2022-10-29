using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._2136_Earliest_Possible_Day_of_Full_Bloom;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.EarliestFullBloom(testCase.PlantTime, testCase.GrowTime), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] PlantTime { get; private init; } = null!;
        public int[] GrowTime { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    PlantTime = new[] { 1, 4, 3 },
                    GrowTime = new[] { 2, 3, 1 },
                    Output = 9,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    PlantTime = new[] { 1, 2, 3, 2 },
                    GrowTime = new[] { 2, 1, 2, 1 },
                    Output = 9,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    PlantTime = new[] { 1 },
                    GrowTime = new[] { 1 },
                    Output = 2,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
