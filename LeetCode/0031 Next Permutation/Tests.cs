using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0031_Next_Permutation;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var nums = testCase.Nums.ToArray();
        solution.NextPermutation(nums);
        Assert.That(nums, Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int[] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 1, 2, 3 },
                    Output = new[] { 1, 3, 2 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 3, 2, 1 },
                    Output = new[] { 1, 2, 3 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 1, 5 },
                    Output = new[] { 1, 5, 1 },
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 2 },
                    Output = new[] { 2, 1 },
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 3, 2 },
                    Output = new[] { 2, 1, 3 },
                    TestCaseName = nameof(Solution2)
                };

                yield return new TestCase
                {
                    Nums = new[] { 5, 1, 1 },
                    Output = new[] { 1, 1, 5 },
                    TestCaseName = nameof(Solution3)
                };
            }
        }
    }
}