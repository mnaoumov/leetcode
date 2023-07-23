using JetBrains.Annotations;

namespace LeetCode._2791_Count_Paths_That_Can_Form_a_Palindrome_in_a_Tree;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CountPalindromePaths(IList<int> parent, string s)
    {
        var n = parent.Count;
        var oddCountLabels = new HashSet<char>[n];
        oddCountLabels[0] = new HashSet<char>();
        var seen = new HashSet<int> { 0 };

        for (var i = 1; i < n; i++)
        {
            Dfs(i);
        }

        return 0L;

        void Dfs(int i)
        {
            if (!seen.Add(i))
            {
                return;
            }

            //var parentLabels = Dfs(parent[i]);
            //oddCountLabels[i] = parentLabels.ToHashSet();

            if (oddCountLabels[i].Contains(s[i]))
            {
                oddCountLabels[i].Remove(s[i]);
            }
            else
            {
                oddCountLabels[i].Add(s[i]);
            }
        }
    }
}
