using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1259_Handshakes_That_Don_t_Cross;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumberOfWays(testCase.NumPeople), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int NumPeople { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
