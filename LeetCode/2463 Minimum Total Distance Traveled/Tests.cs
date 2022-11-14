using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2463_Minimum_Total_Distance_Traveled;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumTotalDistance(testCase.Robot, testCase.Factory), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public IList<int> Robot { get; [UsedImplicitly] init; } = null!;
        public int[][] Factory { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Robot = new[] { 0, 4, 6 },
                    Factory = new[]
                    {
                        new[] { 2, 2 }, new[] { 6, 2 }
                    },
                    Output = 4,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Robot = new[] { 1, -1 },
                    Factory = new[]
                    {
                        new[] { -2, 1 }, new[] { 2, 1 }
                    },
                    Output = 2,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Robot = new[]
                        { 670355988, 403625544, 886437985, 224430896, 126139936, -477101480, -868159607, -293937930 },
                    Factory = new[]
                    {
                        new[] { 333473422, 7 }, new[] { 912209329, 7 }, new[] { 468372740, 7 }, new[] { -765827269, 4 },
                        new[] { 155827122, 4 },
                        new[] { 635462096, 2 }, new[] { -300275936, 2 }, new[] { -115627659, 0 }
                    },
                    Output = 509199280,
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    Robot = new[]
                    {
                        214638235, 856879529, -969013166, -351484621, 257375401, -80547616, 518438404, -997287628,
                        -273117503, 521937307, 975057367, 465488898, -585542166, 272304816, -561624182, 570480701,
                        392705648, -617269032, 574464819, 459492762, -782777452, 677280078, -278094736, -415421399
                    },
                    Factory = new[]
                    {
                        new[] { 321935623, 24 },
                        new[] { 688621920, 16 },
                        new[] { 457918764, 23 },
                        new[] { 177135951, 20 },
                        new[] { 838743003, 16 },
                        new[] { 128256656, 16 },
                        new[] { 844636873, 19 },
                        new[] { -555693914, 4 },
                        new[] { -823965352, 19 },
                        new[] { -566990966, 19 },
                        new[] { 20757380, 23 },
                        new[] { -29163921, 22 },
                        new[] { 370846310, 11 },
                        new[] { 743154667, 13 },
                        new[] { -955988779, 12 },
                        new[] { 100000756, 1 },
                        new[] { 481077983, 11 },
                        new[] { 461542541, 2 },
                        new[] { -17120695, 12 },
                        new[] { -839927181, 3 },
                        new[] { 85595728, 20 },
                        new[] { -834326943, 23 }
                    },
                    Output = 1652544383,
                    TestCaseName = nameof(Solution2)
                };
            }
        }
    }
}
