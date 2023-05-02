using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0125_Valid_Palindrome;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsPalindrome(testCase.S), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
