using JetBrains.Annotations;

namespace LeetCode._2788_Split_Strings_by_Separator;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.SplitWordsBySeparator(testCase.Words, testCase.Separator), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public IList<string> Words { get; [UsedImplicitly] init; } = null!;
        public char Separator { get; [UsedImplicitly] init; }
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
