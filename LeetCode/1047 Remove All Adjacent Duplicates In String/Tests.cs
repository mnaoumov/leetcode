using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._1047_Remove_All_Adjacent_Duplicates_In_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.RemoveDuplicates(testCase.S), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public string Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "abbaca",
                    Output = "ca",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "azxxzy",
                    Output = "ay",
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
