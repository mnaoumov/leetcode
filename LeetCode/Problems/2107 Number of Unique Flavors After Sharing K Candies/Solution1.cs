namespace LeetCode.Problems._2107_Number_of_Unique_Flavors_After_Sharing_K_Candies;

/// <summary>
/// https://leetcode.com/submissions/detail/1453939392/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ShareCandies(int[] candies, int k)
    {
        var counts = candies.GroupBy(candy => candy).ToDictionary(g => g.Key, g => g.Count());

        for (var i = 0; i < k; i++)
        {
            var candy = candies[i];
            counts[candy]--;
            if (counts[candy] == 0)
            {
                counts.Remove(candy);
            }
        }

        var ans = counts.Count;

        for (var i = k; i < candies.Length; i++)
        {
            var candy = candies[i];
            counts[candy]--;
            if (counts[candy] == 0)
            {
                counts.Remove(candy);
            }

            var prevCandy = candies[i - k];
            counts.TryAdd(prevCandy, 0);
            counts[prevCandy]++;
            ans = Math.Max(ans, counts.Count);
        }

        return ans;
    }
}
