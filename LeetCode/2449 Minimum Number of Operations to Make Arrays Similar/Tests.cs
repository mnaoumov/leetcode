using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2449_Minimum_Number_of_Operations_to_Make_Arrays_Similar;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MakeSimilar(testCase.Nums, testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int[] Target { get; private init; } = null!;
        public long Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 8, 12, 6 },
                    Target = new[] { 2, 14, 10 },
                    Output = 2,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 2, 5 },
                    Target = new[] { 4, 1, 3 },
                    Output = 1,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 1, 1, 1, 1 },
                    Target = new[] { 1, 1, 1, 1, 1 },
                    Output = 0,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    Nums = new[]
                    {
                        758, 334, 402, 1792, 1112, 1436, 1534, 1702, 1538, 1427,
                        720, 1424, 114, 1604, 564, 120, 578
                    },
                    Target = new[]
                    {
                        1670, 216, 1392, 1828, 1104, 464, 678, 1134, 644, 1178,
                        1150, 1608, 1799, 1156, 244, 2, 892
                    },
                    Output = 645,
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}