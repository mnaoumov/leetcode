using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0097_Interleaving_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsInterleave(testCase.S1, testCase.S2, testCase.S3), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S1 { get; private init; } = null!;
        public string S2 { get; private init; } = null!;
        public string S3 { get; private init; } = null!;
        public bool Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S1 = "aabcc",
                    // ReSharper disable once StringLiteralTypo
                    S2 = "dbbca",
                    // ReSharper disable once StringLiteralTypo
                    S3 = "aadbbcbcac",
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S1 = "aabcc",
                    // ReSharper disable once StringLiteralTypo
                    S2 = "dbbca",
                    // ReSharper disable once StringLiteralTypo
                    S3 = "aadbbbaccc",
                    Output = false,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S1 = "",
                    S2 = "",
                    S3 = "",
                    Output = true,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    S1 = "aa",
                    S2 = "ab",
                    // ReSharper disable once StringLiteralTypo
                    S3 = "aaba",
                    Output = true,
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    S1 = "abababababababababababababababababababababababababababababababababababababababababababababababababbb",
                    S2 = "abababababababababababababababababababababababababababababababababababababababababababababababababab",
                    S3 = "abababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababababbb",
                    Output = true,
                    TestCaseName = nameof(Solution2)
                };

                yield return new TestCase
                {
                    S1 = "a",
                    S2 = "",
                    S3 = "a",
                    Output = true,
                    TestCaseName = nameof(Solution4)
                };

                yield return new TestCase
                {
                    S1 = "a",
                    S2 = "b",
                    S3 = "ab",
                    Output = true,
                    TestCaseName = nameof(Solution5)
                };

                yield return new TestCase
                {
                    S1 = "aa",
                    S2 = "ab",
                    // ReSharper disable once StringLiteralTypo
                    S3 = "abaa",
                    Output = true,
                    TestCaseName = nameof(Solution6)
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S1 = "bbbcc",
                    // ReSharper disable once StringLiteralTypo
                    S2 = "bbaccbbbabcacc",
                    // ReSharper disable once StringLiteralTypo
                    S3 = "bbbbacbcccbcbabbacc",
                    Output = false,
                    TestCaseName = nameof(Solution7)
                };
            }
        }
    }
}