
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0438_Find_All_Anagrams_in_a_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindAnagrams(testCase.S, testCase.P), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public string P { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
