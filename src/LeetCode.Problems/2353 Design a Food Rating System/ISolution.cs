namespace LeetCode.Problems._2353_Design_a_Food_Rating_System;

[PublicAPI]
public interface ISolution
{
    IFoodRatings Create(string[] foods, string[] cuisines, int[] ratings);
}
