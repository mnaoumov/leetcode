using JetBrains.Annotations;

namespace LeetCode._2456_Most_Popular_Video_Creator;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MostPopularCreator(testCase.Creators, testCase.Ids, testCase.Views), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string[] Creators { get; [UsedImplicitly] init; } = null!;
        public string[] Ids { get; [UsedImplicitly] init; } = null!;
        public int[] Views { get; [UsedImplicitly] init; } = null!;
        public IList<IList<string>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
