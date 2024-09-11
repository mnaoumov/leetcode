namespace LeetCode.Problems._1598_Crawler_Log_Folder;

/// <summary>
/// https://leetcode.com/submissions/detail/1315784074/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinOperations(string[] logs)
    {
        var ans = 0;

        foreach (var log in logs)
        {
            if (log == "../")
            {
                ans = Math.Max(0, ans - 1);
            }
            else if (log != "./")
            {
                ans += 1;
            }
        }

        return ans;
    }
}
