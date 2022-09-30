using NUnit.Framework;

namespace LeetCode._028_Find_the_Index_of_the_First_Occurrence_in_a_String;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.StrStr(testCase.HayStack, testCase.Needle), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string HayStack { get; private init; } = null!;
        public string Needle { get; private init; } = null!;
        public int Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    HayStack = "sadbutsad",
                    Needle = "sad",
                    Return = 0,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    HayStack = "leetcode",
                    Needle = "leeto",
                    Return = -1,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}