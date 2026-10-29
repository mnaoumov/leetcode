namespace LeetCode.Problems._3597_Partition_String;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-456/problems/partition-string/submissions/1679863707/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> PartitionString(string s)
    {
        var ans = new List<string>();
        var set = new HashSet<string>();
        var currentStr = "";

        foreach (var letter in s)
        {
            currentStr += letter;

            if (!set.Add(currentStr))
            {
                continue;
            }

            ans.Add(currentStr);
            currentStr = "";
        }

        return ans;
    }
}
