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
        public string S { get; private init; } = null!;
        public IList<string> Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "25525511135",
                    Output = new[] { "255.255.11.135", "255.255.111.35" },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "0000",
                    Output = new[] { "0.0.0.0" },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "101023",
                    Output = new[] { "1.0.10.23", "1.0.102.3", "10.1.0.23", "10.10.2.3", "101.0.2.3" },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}