namespace LeetCode.Problems._3168_Minimum_Number_of_Chairs_in_a_Waiting_Room;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-400/submissions/detail/1274694991/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumChairs(string s)
    {
        const char enter = 'E';
        const char leave = 'L';

        var ans = 0;
        var currentNeed = 0;

        foreach (var letter in s)
        {
            switch (letter)
            {
                case enter:
                    currentNeed++;
                    ans = Math.Max(ans, currentNeed);
                    break;
                case leave:
                    currentNeed--;
                    break;
            }
        }

        return ans;
    }
}
