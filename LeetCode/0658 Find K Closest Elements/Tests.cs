using NUnit.Framework;

namespace LeetCode._0658_Find_K_Closest_Elements;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindClosestElements(testCase.Arr, testCase.K, testCase.X), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Arr { get; private init; } = null!;
        public int K { get; private init; }
        public int X { get; private init; }
        public int[] Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Arr = new[] { 1, 2, 3, 4, 5 },
                    K = 4,
                    X = 3,
                    Return = new[] { 1, 2, 3, 4 },
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    Arr = new[] { 1, 2, 3, 4, 5 },
                    K = 4,
                    X = -1,
                    Return = new[] { 1, 2, 3, 4 },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
