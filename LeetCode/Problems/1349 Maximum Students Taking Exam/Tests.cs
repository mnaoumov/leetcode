using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1349_Maximum_Students_Taking_Exam;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxStudents(testCase.Seats), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public char[][] Seats { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
