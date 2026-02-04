namespace LeetCode.Problems._2115_Find_All_Possible_Recipes_from_Given_Supplies;

[PublicAPI]
public interface ISolution
{
    IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies);
}
