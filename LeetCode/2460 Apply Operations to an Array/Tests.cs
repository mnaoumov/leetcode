using JetBrains.Annotations;

namespace LeetCode._2460_Apply_Operations_to_an_Array;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ApplyOperations(testCase.Nums), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 1, 2, 2, 1, 1, 0 },
                    Output = new[] { 1, 4, 2, 0, 0, 0 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 0, 1 },
                    Output = new[] { 1, 0 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[]
                    {
                        312, 312, 436, 892, 0, 0, 528, 0, 686, 516, 0, 0, 0, 0, 0, 445, 445, 445, 445, 445, 445, 984,
                        984, 984, 0, 0, 0, 0, 168, 0, 0, 647, 41, 203, 203, 241, 241, 0, 628, 628, 0, 875, 875, 0, 0, 0,
                        803, 803, 54, 54, 852, 0, 0, 0, 958, 195, 590, 300, 126, 0, 0, 523, 523
                    },
                    Output = new[]
                    {
                        624, 436, 892, 528, 686, 516, 890, 890, 890, 1968, 984, 168, 647, 41, 406, 482, 1256, 1750,
                        1606, 108, 852, 958, 195, 590, 300, 126, 1046, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
                    },
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}
