using NUnit.Framework;

namespace LeetCode._0071_Simplify_Path;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SimplifyPath(testCase.Path), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string Path { get; private init; } = null!;
        public string Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Path = "/home/",
                    Output = "/home",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Path = "/../",
                    Output = "/",
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Path = "/home//foo/",
                    Output = "/home/foo",
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}