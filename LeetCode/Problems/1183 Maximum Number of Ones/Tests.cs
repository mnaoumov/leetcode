using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._1183_Maximum_Number_of_Ones;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaximumNumberOfOnes(testCase.Width, testCase.Height, testCase.SideLength, testCase.MaxOnes), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Width { get; [UsedImplicitly] init; }
        public int Height { get; [UsedImplicitly] init; }
        public int SideLength { get; [UsedImplicitly] init; }
        public int MaxOnes { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
