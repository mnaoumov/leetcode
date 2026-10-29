namespace LeetCode.Problems._2115_Find_All_Possible_Recipes_from_Given_Supplies;

/// <summary>
/// https://leetcode.com/problems/find-all-possible-recipes-from-given-supplies/submissions/1581804769/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
    {
        var recipesIngredientsLeftMap = new Dictionary<string, int>();

        var n = recipes.Length;
        var recipesByIngredients = new Dictionary<string, List<string>>();

        for (var i = 0; i < n; i++)
        {
            var recipe = recipes[i];
            var ingredientsForRecipe = ingredients[i];

            foreach (var ingredient in ingredientsForRecipe)
            {
                recipesByIngredients.TryAdd(ingredient, new List<string>());
                recipesByIngredients[ingredient].Add(recipe);
            }

            recipesIngredientsLeftMap[recipe] = ingredientsForRecipe.Count;
        }

        var queue = new Queue<string>(supplies);
        var ans = new List<string>();

        var seen = new HashSet<string>();

        while (queue.Count > 0)
        {
            var ingredient = queue.Dequeue();

            if (!seen.Add(ingredient))
            {
                continue;
            }

            if (recipesIngredientsLeftMap.ContainsKey(ingredient))
            {
                recipesIngredientsLeftMap[ingredient]--;

                if (recipesIngredientsLeftMap[ingredient] == 0)
                {
                }

                ans.Add(ingredient);
            }

            foreach (var recipe in recipesByIngredients.GetValueOrDefault(ingredient, new List<string>()))
            {
                queue.Enqueue(recipe);
            }
        }

        return ans;
    }
}
