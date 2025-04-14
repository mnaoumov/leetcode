namespace LeetCode.Problems._2115_Find_All_Possible_Recipes_from_Given_Supplies;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.FindAllRecipes(testCase.Recipes, testCase.Ingredients, testCase.Supplies), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string[] Recipes { get; [UsedImplicitly] init; } = null!;
        public IList<IList<string>> Ingredients { get; [UsedImplicitly] init; } = null!;
        public string[] Supplies { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
