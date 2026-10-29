namespace LeetCode.Problems._1233_Remove_Sub_Folders_from_the_Filesystem;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.RemoveSubfolders(testCase.Folder), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string[] Folder { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
