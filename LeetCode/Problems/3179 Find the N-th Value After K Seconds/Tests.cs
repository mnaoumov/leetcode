using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._3179_Find_the_N_th_Value_After_K_Seconds;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ValueAfterKSeconds(testCase.N, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
