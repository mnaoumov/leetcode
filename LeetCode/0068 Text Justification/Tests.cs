using JetBrains.Annotations;

namespace LeetCode._0068_Text_Justification;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FullJustify(testCase.Words, testCase.MaxWidth), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string[] Words { get; [UsedImplicitly] init; } = null!;
        public int MaxWidth { get; [UsedImplicitly] init; }
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}