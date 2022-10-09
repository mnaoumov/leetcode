﻿namespace LeetCode._0049_Group_Anagrams;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentIgnoringItemOrderWithDetails(solution.GroupAnagrams(testCase.Strs), testCase.Return);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string[] Strs { get; private init; } = null!;
        public IList<IList<string>> Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Strs = new[] { "eat", "tea", "tan", "ate", "nat", "bat" },
                    Return = new IList<string>[]
                    {
                        new[] { "bat" },
                        new[] { "nat", "tan" },
                        new[] { "ate", "eat", "tea" }
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Strs = new[] { "" },
                    Return = new IList<string>[]
                    {
                        new[] { "" }
                    },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Strs = new[] { "a" },
                    Return = new IList<string>[]
                    {
                        new[] { "a" }
                    },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}