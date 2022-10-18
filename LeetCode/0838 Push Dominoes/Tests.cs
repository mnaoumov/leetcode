using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0838_Push_Dominoes;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.PushDominoes(testCase.Dominoes), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string Dominoes { get; private init; } = null!;
        public string Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Dominoes = "RR.L",
                    Output = "RR.L",
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    Dominoes = ".L.R...LR..L..",
                    // ReSharper disable once StringLiteralTypo
                    Output = "LL.RR.LLRRLL..",
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
