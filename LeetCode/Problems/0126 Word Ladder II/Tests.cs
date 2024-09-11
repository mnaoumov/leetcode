using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0126_Word_Ladder_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.FindLadders(testCase.BeginWord, testCase.EndWord, testCase.WordList), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string BeginWord { get; [UsedImplicitly] init; } = null!;
        public string EndWord { get; [UsedImplicitly] init; } = null!;
        public IList<string> WordList { get; [UsedImplicitly] init; } = null!;
        public IList<IList<string>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
