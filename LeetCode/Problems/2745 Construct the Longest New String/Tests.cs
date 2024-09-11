using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2745_Construct_the_Longest_New_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LongestString(testCase.X, testCase.Y, testCase.Z), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int X { get; [UsedImplicitly] init; }
        public int Y { get; [UsedImplicitly] init; }
        public int Z { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
