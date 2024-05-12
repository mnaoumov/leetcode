using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2825_Make_String_a_Subsequence_Using_Cyclic_Increments;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CanMakeSubsequence(testCase.Str1, testCase.Str2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Str1 { get; [UsedImplicitly] init; } = null!;
        public string Str2 { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
