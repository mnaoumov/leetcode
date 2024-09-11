using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2839_Check_if_Strings_Can_be_Made_Equal_With_Operations_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CanBeEqual(testCase.S1, testCase.S2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S1 { get; [UsedImplicitly] init; } = null!;
        public string S2 { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
