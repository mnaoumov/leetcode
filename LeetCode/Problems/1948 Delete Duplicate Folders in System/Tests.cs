namespace LeetCode.Problems._1948_Delete_Duplicate_Folders_in_System;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.DeleteDuplicateFolder(testCase.Paths), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public IList<IList<string>> Paths { get; [UsedImplicitly] init; } = null!;
        public IList<IList<string>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
