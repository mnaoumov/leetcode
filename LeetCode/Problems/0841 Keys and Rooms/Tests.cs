using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0841_Keys_and_Rooms;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CanVisitAllRooms(testCase.Rooms), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public IList<IList<int>> Rooms { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
