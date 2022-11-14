using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0096_Unique_Binary_Search_Trees;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumTrees(testCase.N), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    N = 3,
                    Output = 5,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    N = 1,
                    Output = 1,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}