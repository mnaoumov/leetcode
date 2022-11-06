using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0899_Orderly_Queue;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.OrderlyQueue(testCase.S, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public int K { get; private init; }
        public string Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "cba",
                    K = 1,
                    Output = "acb",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "baaca",
                    K = 3,
                    // ReSharper disable once StringLiteralTypo
                    Output = "aaabc",
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "v",
                    K = 1,
                    Output = "v",
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    S = "kuh",
                    K = 1,
                    Output = "hku",
                    TestCaseName = nameof(Solution2)
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "nhtq",
                    K = 1,
                    // ReSharper disable once StringLiteralTypo
                    Output = "htqn",
                    TestCaseName = nameof(Solution3)
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "xmvzi",
                    K = 2,
                    // ReSharper disable once StringLiteralTypo
                    Output = "imvxz",
                    TestCaseName = nameof(Solution4)
                };
            }
        }
    }
}
