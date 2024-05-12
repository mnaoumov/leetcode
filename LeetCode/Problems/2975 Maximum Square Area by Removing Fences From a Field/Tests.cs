using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._2975_Maximum_Square_Area_by_Removing_Fences_From_a_Field;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaximizeSquareArea(testCase.M, testCase.N, testCase.HFences, testCase.VFences), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int M { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public int[] HFences { get; [UsedImplicitly] init; } = null!;
        public int[] VFences { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
