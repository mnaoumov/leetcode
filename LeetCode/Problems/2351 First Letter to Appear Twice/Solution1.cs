using JetBrains.Annotations;

namespace LeetCode._2351_First_Letter_to_Appear_Twice;

/// <summary>
/// https://leetcode.com/submissions/detail/856282690/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public char RepeatedCharacter(string s)
    {
        var set = new HashSet<char>();
        return s.First(letter => !set.Add(letter));
    }
}
