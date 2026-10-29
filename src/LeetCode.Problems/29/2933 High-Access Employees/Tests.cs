namespace LeetCode.Problems._2933_High_Access_Employees;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.FindHighAccessEmployees(testCase.Access_times), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        // ReSharper disable once InconsistentNaming
        public IList<IList<string>> Access_times { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
