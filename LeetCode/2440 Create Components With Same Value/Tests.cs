using NUnit.Framework;

namespace LeetCode._2440_Create_Components_With_Same_Value;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ComponentValue(testCase.Nums, testCase.Edges), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int[][] Edges { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 6, 2, 2, 2, 6 },
                    Edges = new[] { new[] { 0, 1 }, new[] { 1, 2 }, new[] { 1, 3 }, new[] { 3, 4 } },
                    Output = 2,
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    Nums = new[] { 2 },
                    Edges = Array.Empty<int[]>(),
                    Output = 0,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}