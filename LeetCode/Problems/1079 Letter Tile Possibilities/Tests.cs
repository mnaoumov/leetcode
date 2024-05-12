using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._1079_Letter_Tile_Possibilities;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumTilePossibilities(testCase.Tiles), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Tiles { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
