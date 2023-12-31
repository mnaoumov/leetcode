using JetBrains.Annotations;

namespace LeetCode._1897_Redistribute_Characters_to_Make_All_Strings_Equal;

/// <summary>
/// https://leetcode.com/submissions/detail/1131835626/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool MakeEqual(string[] words)
    {
        var counts = new Dictionary<char, int>();

        foreach (var word in words)
        {
            foreach (var letter in word)
            {
                counts.TryAdd(letter, 0);
                counts[letter]++;
            }
        }

        return counts.Values.All(count => count % words.Length == 0);
    }
}
