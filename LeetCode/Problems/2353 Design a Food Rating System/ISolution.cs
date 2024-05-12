using JetBrains.Annotations;

namespace LeetCode.Problems._2353_Design_a_Food_Rating_System;

[PublicAPI]
public interface ISolution
{
    public IFoodRatings Create(string[] foods, string[] cuisines, int[] ratings);
}
