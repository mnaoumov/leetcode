using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0009_Palindrome_Number;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsPalindrome(testCase.X), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int X { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }
    }
}