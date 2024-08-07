using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._1105_Filling_Bookcase_Shelves;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinHeightShelves(testCase.Books, testCase.ShelfWidth), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Books { get; [UsedImplicitly] init; } = null!;
        public int ShelfWidth { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
