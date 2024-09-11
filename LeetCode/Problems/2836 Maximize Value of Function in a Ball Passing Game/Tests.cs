using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2836_Maximize_Value_of_Function_in_a_Ball_Passing_Game;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GetMaxFunctionValue(testCase.Receiver, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public IList<int> Receiver { get; [UsedImplicitly] init; } = null!;
        public long K { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
