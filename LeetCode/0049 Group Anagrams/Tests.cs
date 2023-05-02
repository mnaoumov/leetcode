using JetBrains.Annotations;

namespace LeetCode._0049_Group_Anagrams;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentIgnoringItemOrderWithDetails(solution.GroupAnagrams(testCase.Strs), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string[] Strs { get; [UsedImplicitly] init; } = null!;
        public IList<IList<string>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
