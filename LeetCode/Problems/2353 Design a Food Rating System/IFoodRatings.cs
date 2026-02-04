namespace LeetCode.Problems._2353_Design_a_Food_Rating_System;

[PublicAPI]
public interface IFoodRatings
{
    void ChangeRating(string food, int newRating);
    string HighestRated(string cuisine);
}
