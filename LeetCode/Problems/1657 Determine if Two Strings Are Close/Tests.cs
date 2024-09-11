using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1657_Determine_if_Two_Strings_Are_Close;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CloseStrings(testCase.Word1, testCase.Word2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Word1 { get; [UsedImplicitly] init; } = null!;
        public string Word2 { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
