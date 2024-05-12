using JetBrains.Annotations;

namespace LeetCode.Problems._2353_Design_a_Food_Rating_System;

[PublicAPI]
public interface IFoodRatings
{
    public void ChangeRating(string food, int newRating);
    public string HighestRated(string cuisine);
}
