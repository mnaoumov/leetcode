using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._0489_Robot_Room_Cleaner;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var robot = new Robot(testCase.Room, testCase.Row, testCase.Col);
        solution.CleanRoom(robot);
        Assert.That(robot.VisitedAllRooms, Is.EqualTo(testCase.VisitedAllRooms));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Room { get; [UsedImplicitly] init; } = null!;
        public int Row { get; [UsedImplicitly] init; }
        public int Col { get; [UsedImplicitly] init; }
        public bool VisitedAllRooms { get; [UsedImplicitly] init; }
    }
}
