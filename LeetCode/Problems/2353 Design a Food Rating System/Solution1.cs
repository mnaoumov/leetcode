using JetBrains.Annotations;

namespace LeetCode.Problems._2353_Design_a_Food_Rating_System;

/// <summary>
/// https://leetcode.com/submissions/detail/1121403827/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IFoodRatings Create(string[] foods, string[] cuisines, int[] ratings) => new FoodRatings(foods, cuisines, ratings);

    private class FoodRatings : IFoodRatings
    {
        private readonly Dictionary<string, int> _foodRatings = new();
        private readonly Dictionary<string, PriorityQueue<(string food, int rating), (int negateRating, string food)>> _cuisinePqs = new();
        private readonly Dictionary<string, string> _foodCuisineMap = new();

        public FoodRatings(IReadOnlyList<string> foods, IReadOnlyList<string> cuisines, IReadOnlyList<int> ratings)
        {
            var n = foods.Count;

            for (var i = 0; i < n; i++)
            {
                var food = foods[i];
                var cuisine = cuisines[i];
                var rating = ratings[i];

                _foodRatings[food] = rating;
                _cuisinePqs.TryAdd(cuisine, new PriorityQueue<(string food, int rating), (int negateRating, string food)>());
                _cuisinePqs[cuisine].Enqueue((food, rating), (-rating, food));
                _foodCuisineMap[food] = cuisine;
            }
        }
    
        public void ChangeRating(string food, int newRating)
        {
            _foodRatings[food] = newRating;
            var cuisine = _foodCuisineMap[food];
            var pq = _cuisinePqs[cuisine];
            pq.Enqueue((food, newRating), (-newRating, food));
        }
    
        public string HighestRated(string cuisine)
        {
            var pq = _cuisinePqs[cuisine];

            while (true)
            {
                var (food, rating) = pq.Peek();

                if (_foodRatings[food] == rating)
                {
                    break;
                }

                pq.Dequeue();
            }

            return pq.Peek().food;
        }
    }
}
