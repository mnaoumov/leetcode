using NUnit.Framework;

namespace LeetCode._838_Push_Dominoes;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.PushDominoes(testCase.Dominoes), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string Dominoes { get; private init; } = null!;
        public string Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Dominoes = "RR.L",
                    Return = "RR.L",
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    Dominoes = ".L.R...LR..L..",
                    Return = "LL.RR.LLRRLL..",
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
