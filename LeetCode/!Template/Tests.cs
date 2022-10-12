using NUnit.Framework;

namespace LeetCode._Template;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Method1(testCase.Arg1, testCase.Arg2, testCase.Arg3), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Arg1 { get; private init; } = null!;
        public int Arg2 { get; private init; }
        public string Arg3 { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Arg1 = new[] { 1, 2, 3 },
                    Arg2 = 4,
                    Arg3 = "a",
                    Output = 42,
                    TestCaseName = "Example 1"
                };
            }
        }
    }
}