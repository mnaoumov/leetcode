namespace LeetCode.Problems._3295_Report_Spam_Message;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-416/submissions/detail/1397966326/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool ReportSpam(string[] message, string[] bannedWords)
    {
        var bannedWordsSet = new HashSet<string>(bannedWords);

        var bannedWordsCount = 0;

        foreach (var word in message)
        {
            if (!bannedWordsSet.Contains(word))
            {
                continue;
            }

            bannedWordsCount++;

            if (bannedWordsCount == 2)
            {
                return true;
            }
        }

        return false;
    }
}
