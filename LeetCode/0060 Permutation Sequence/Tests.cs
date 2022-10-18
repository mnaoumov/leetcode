using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0060_Permutation_Sequence;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GetPermutation(testCase.N, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; private init; }
        public int K { get; private init; }
        public string Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    N = 3,
                    K = 3,
                    Output = "213",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    N = 4,
                    K = 9,
                    Output = "2314",
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    N = 3,
                    K = 1,
                    Output = "123",
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}