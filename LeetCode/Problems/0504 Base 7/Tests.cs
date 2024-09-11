using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0504_Base_7;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ConvertToBase7(testCase.Num), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Num { get; [UsedImplicitly] init; }
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
