namespace LeetCode.Problems._2211_Count_Collisions_on_a_Road;

/// <summary>
/// https://leetcode.com/problems/count-collisions-on-a-road/submissions/1846371446/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountCollisions(string directions)
    {
        var ans = 0;
        var startIndex = 0;
        var n = directions.Length;
        const char left = 'L';
        const char right = 'R';
        const char stay = 'S';
        while (startIndex < n && directions[startIndex] == left)
        {
            startIndex++;
        }

        var endIndex = n - 1;
        while (endIndex >= startIndex && directions[endIndex] == right)
        {
            endIndex--;
        }

        for (var i = startIndex; i <= endIndex; i++)
        {
            var direction = directions[i];
            if (direction == stay)
            {
                continue;
            }

            ans++;
        }

        return ans;
    }
}
