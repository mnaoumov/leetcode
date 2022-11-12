using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2467_Most_Profitable_Path_in_a_Tree;

[UsedImplicitly]
public partial class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MostProfitablePath(testCase.Edges, testCase.Bob, testCase.Amount), Is.EqualTo(testCase.Output));
    }

    public partial class TestCase : TestCaseBase<TestCase>
    {
        public int[][] Edges { get; private init; } = null!;
        public int Bob { get; private init; }
        public int[] Amount { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCaseBuilder<TestCase>> TestCaseBuilders
        {
            get
            {
                yield return new TestCaseBuilder<TestCase>
                {
                    TestCaseName = "Example 1",
                    TestCaseFunc = () => new TestCase
                    {
                        Edges = new[]
                        {
                            new[] { 0, 1 }, new[] { 1, 2 }, new[] { 1, 3 }, new[] { 3, 4 }
                        },
                        Bob = 3,
                        Amount = new[] { -2, 4, 2, -4, 6 },
                        Output = 6
                    }
                };

                yield return new TestCaseBuilder<TestCase>
                {
                    TestCaseName = "Example 2",
                    TestCaseFunc = () => new TestCase
                    {
                        Edges = new[]
                        {
                            new[] { 0, 1 }
                        },
                        Bob = 1,
                        Amount = new[] { -7280, 2350 },
                        Output = -7280,
                        TestCaseName = "Example 2"
                    }
                };

                yield return new TestCaseBuilder<TestCase>
                {
                    TestCaseName = nameof(Solution1),
                    TestCaseFunc = TestCase3
                };

                yield return new TestCaseBuilder<TestCase>
                {
                    TestCaseName = nameof(Solution4),
                    Timeout = TimeSpan.FromSeconds(1),
                    TestCaseFunc = TestCase4
                };
            }
        }
    }
}
