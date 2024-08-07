using JetBrains.Annotations;

namespace LeetCode.Problems._1395_Count_Number_of_Teams;

/// <summary>
/// https://leetcode.com/submissions/detail/1336925349/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumTeams(int[] rating)
    {
        var n = rating.Length;
        var strictlyGreaterLists = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();
        var strictlyLessLists = Enumerable.Repeat(0, n).Select(_ => new List<int>()).ToArray();

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                if (rating[j] > rating[i])
                {
                    strictlyGreaterLists[i].Add(j);
                }
                else if (rating[j] < rating[i])
                {
                    strictlyLessLists[i].Add(j);
                }
            }
        }

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            ans += strictlyGreaterLists[i].Sum(j => strictlyGreaterLists[j].Count);
            ans += strictlyLessLists[i].Sum(j => strictlyLessLists[j].Count);
        }

        return ans;
    }
}
