using JetBrains.Annotations;

namespace LeetCode._0131_Palindrome_Partitioning;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<IList<string>> Partition(string s)
    {
        var result = new List<IList<string>>();
        var partition = new List<string>();
        Backtrack(0);
        return result;

        void Backtrack(int i)
        {
            if (i == s.Length)
            {
                result.Add(partition.ToArray());
                return;
            }

            for (var j = i; j < s.Length; j++)
            {
                var isPalindrome = true;
                var start = i;
                var end  = j;

                while (start < end)
                {
                    if (s[start] != s[end])
                    {
                        isPalindrome = false;
                        break;
                    }

                    start++;
                    end--;
                }

                if (!isPalindrome)
                {
                    continue;
                }

                partition.Add(s[i..(j + 1)]);
                Backtrack(j + 1);
                partition.RemoveAt(partition.Count - 1);
            }
        }
    }
}
