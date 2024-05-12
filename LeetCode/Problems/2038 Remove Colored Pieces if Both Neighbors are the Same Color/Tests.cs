using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._2038_Remove_Colored_Pieces_if_Both_Neighbors_are_the_Same_Color;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.WinnerOfGame(testCase.Colors), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Colors { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
