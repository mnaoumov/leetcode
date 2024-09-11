using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0474_Ones_and_Zeroes;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindMaxForm(testCase.Strs, testCase.M, testCase.N), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string[] Strs { get; [UsedImplicitly] init; } = null!;
        public int M { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
