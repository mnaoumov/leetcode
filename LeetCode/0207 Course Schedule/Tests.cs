using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0207_Course_Schedule;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CanFinish(testCase.NumCourses, testCase.Prerequisites), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int NumCourses { get; [UsedImplicitly] init; }
        public int[][] Prerequisites { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}