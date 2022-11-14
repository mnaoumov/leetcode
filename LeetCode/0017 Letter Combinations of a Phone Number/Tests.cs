using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0017_Letter_Combinations_of_a_Phone_Number;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LetterCombinations(testCase.Digits), Is.EquivalentTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Digits { get; [UsedImplicitly] init; } = null!;
        public string[] Output { get; [UsedImplicitly] init; } = null!;
    }
}