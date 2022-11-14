using JetBrains.Annotations;

namespace LeetCode._0208_Implement_Trie__Prefix_Tree_;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var sut = solution.Create();
        testCase.Test(sut);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public Action<ITrie> Test { get; [UsedImplicitly] init; } = null!;
    }
}