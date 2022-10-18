using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0091_Decode_Ways;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumDecodings(testCase.S), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "12",
                    Output = 2,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "226",
                    Output = 3,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}