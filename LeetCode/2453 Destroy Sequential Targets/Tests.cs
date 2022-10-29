using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2453_Destroy_Sequential_Targets;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.DestroyTargets(testCase.Nums, testCase.Space), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int Space { get; private init; }
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 3, 7, 8, 1, 1, 5 },
                    Space = 2,
                    Output = 1,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 3, 5, 2, 4, 6 },
                    Space = 2,
                    Output = 1,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { 6, 2, 5 },
                    Space = 100,
                    Output = 2,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
