namespace LeetCode.Problems._2115_Find_All_Possible_Recipes_from_Given_Supplies;

/// <summary>
/// https://leetcode.com/problems/find-all-possible-recipes-from-given-supplies/submissions/1581810689/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
    {
        var recipesIngredientsLeftMap = new Dictionary<string, HashSet<string>>();

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

            recipesIngredientsLeftMap[recipe] = ingredientsForRecipe.ToHashSet();
        }

        var queue = new Queue<string>(supplies);
        var set = new HashSet<string>();

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
                set.Add(ingredient);
            }

            foreach (var recipe in recipesByIngredients.GetValueOrDefault(ingredient, new List<string>()))
            {
                if (!recipesIngredientsLeftMap.TryGetValue(recipe, out var recipesIngredientsLeft))
                {
                    queue.Enqueue(recipe);
                    continue;
                }

                recipesIngredientsLeft.Remove(ingredient);

                if (recipesIngredientsLeft.Count == 0)
                {
                    queue.Enqueue(recipe);
                }
            }
        }

        return set.ToList();
    }
}
