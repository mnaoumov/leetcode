using NUnit.Framework;

namespace LeetCode._1531_String_Compression_II;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GetLengthOfOptimalCompression(testCase.S, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public int K { get; private init; }
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "aaabcccd",
                    K = 2,
                    Output = 4,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "aabbaa",
                    K = 2,
                    Output = 2,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "aaaaaaaaaaa",
                    K = 0,
                    Output = 3,
                    TestCaseName = "Example 3"
                };
                
                yield return new TestCase
                {
                    S = "aaaabbab",
                    K = 3,
                    Output = 2,
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    S = "abcdefghijklmnopqrstuvwxyz",
                    K = 16,
                    Output = 20,
                    TestCaseName = nameof(Solution2)
                };

            }
        }
    }
}