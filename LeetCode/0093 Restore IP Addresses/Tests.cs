using JetBrains.Annotations;

namespace LeetCode._0093_Restore_IP_Addresses;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.RestoreIpAddresses(testCase.S), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}