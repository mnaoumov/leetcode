using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0079_Word_Search;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Exist(testCase.Board, testCase.Word), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public char[][] Board { get; [UsedImplicitly] init; } = null!;
        public string Word { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
