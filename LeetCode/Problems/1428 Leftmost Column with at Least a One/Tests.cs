using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._1428_Leftmost_Column_with_at_Least_a_One;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LeftMostColumnWithOne(new BinaryMatrix(testCase.Mat)), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Mat { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
