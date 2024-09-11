using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2533_Number_of_Good_Binary_Strings;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GoodBinaryStrings(testCase.MinLength, testCase.MaxLength, testCase.OneGroup, testCase.ZeroGroup), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int MinLength { get; [UsedImplicitly] init; }
        public int MaxLength { get; [UsedImplicitly] init; }
        public int OneGroup { get; [UsedImplicitly] init; }
        public int ZeroGroup { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
