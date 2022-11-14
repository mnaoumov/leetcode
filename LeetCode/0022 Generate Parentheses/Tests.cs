using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0022_Generate_Parentheses;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GenerateParenthesis(testCase.N),
            Is.EquivalentTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; [UsedImplicitly] init; }
        public string[] Output { get; [UsedImplicitly] init; } = null!;
    }
}