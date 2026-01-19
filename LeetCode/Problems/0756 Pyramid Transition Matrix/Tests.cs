namespace LeetCode.Problems._0756_Pyramid_Transition_Matrix;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.PyramidTransition(testCase.Bottom, testCase.Allowed), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Bottom { get; [UsedImplicitly] init; } = null!;
        public IList<string> Allowed { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
