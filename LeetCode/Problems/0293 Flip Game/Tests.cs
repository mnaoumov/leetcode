using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0293_Flip_Game;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.GeneratePossibleNextMoves(testCase.CurrentState), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string CurrentState { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
