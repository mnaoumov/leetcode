namespace LeetCode.Problems._3386_Button_with_Longest_Push_Time;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-428/submissions/detail/1479012248/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ButtonWithLongestTime(int[][] events)
    {
        var lastTime = 0;
        var maxDuration = 0;
        var ans = 0;

        foreach (var @event in events)
        {
            var index = @event[0];
            var time = @event[1];
            var duration = time - lastTime;
            lastTime = time;

            if (duration < maxDuration)
            {
                continue;
            }

            if (duration > maxDuration)
            {
                maxDuration = duration;
                ans = index;
            }
            else if (index < ans)
            {
                ans = index;
            }
        }

        return ans;
    }
}
