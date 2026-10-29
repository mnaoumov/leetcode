namespace LeetCode.Problems._1007_Minimum_Domino_Rotations_For_Equal_Row;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinDominoRotations(testCase.Tops, testCase.Bottoms), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Tops { get; [UsedImplicitly] init; } = null!;
        public int[] Bottoms { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
