using JetBrains.Annotations;

namespace LeetCode._0692_Top_K_Frequent_Words;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.TopKFrequent(testCase.Words, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string[] Words { get; private init; } = null!;
        public int K { get; private init; }
        public IList<string> Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Words = new[] { "i", "love", "leetcode", "i", "love", "coding" },
                    K = 2,
                    Output = new[] { "i", "love" },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Words = new[] { "the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is" },
                    K = 4,
                    Output = new[] { "the", "is", "sunny", "day" },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}