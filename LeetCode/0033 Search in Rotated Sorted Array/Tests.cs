using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0033_Search_in_Rotated_Sorted_Array;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Search(testCase.Nums, testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int Target { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 4, 5, 6, 7, 0, 1, 2 },
                    Target = 0,
                    Output = 4,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 4, 5, 6, 7, 0, 1, 2 },
                    Target = 3,
                    Output = -1,
                    TestCaseName = "Example 2"
                };
                
                yield return new TestCase
                {
                    Nums = new[] { 1 },
                    Target = 0,
                    Output = -1,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}