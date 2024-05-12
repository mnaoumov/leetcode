using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._0946_Validate_Stack_Sequences;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ValidateStackSequences(testCase.Pushed, testCase.Popped), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Pushed { get; [UsedImplicitly] init; } = null!;
        public int[] Popped { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
