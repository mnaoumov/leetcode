namespace LeetCode.Problems._2273_Find_Resultant_Array_After_Removing_Anagrams;

/// <summary>
/// https://leetcode.com/problems/find-resultant-array-after-removing-anagrams/submissions/1799855320/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> RemoveAnagrams(string[] words)
    {
        var ans = new List<string>();

        var lastSortedWord = "";
        foreach (var word in words)
        {
            var sortedWord = string.Concat(word.OrderBy(letter => letter));

            if (lastSortedWord == sortedWord)
            {
                continue;
            }

            ans.Add(word);
            lastSortedWord = sortedWord;
        }

        return ans;
    }
}
