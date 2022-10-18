using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0028_Find_the_Index_of_the_First_Occurrence_in_a_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.StrStr(testCase.HayStack, testCase.Needle), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string HayStack { get; private init; } = null!;
        public string Needle { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    HayStack = "sadbutsad",
                    Needle = "sad",
                    Output = 0,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    HayStack = "leetcode",
                    // ReSharper disable once StringLiteralTypo
                    Needle = "leeto",
                    Output = -1,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}