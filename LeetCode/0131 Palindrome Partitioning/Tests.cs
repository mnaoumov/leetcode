using JetBrains.Annotations;

namespace LeetCode._0131_Palindrome_Partitioning;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.Partition(testCase.S), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public IList<IList<string>> Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "aab",
                    Output = new IList<string>[]
                    {
                        new[] { "a", "a", "b" }, new[] { "aa", "b" }
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "a",
                    Output = new IList<string>[]
                    {
                        new[] { "a" }
                    },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
