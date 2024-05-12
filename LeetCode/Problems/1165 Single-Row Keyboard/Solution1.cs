using JetBrains.Annotations;

namespace LeetCode._1165_Single_Row_Keyboard;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CalculateTime(string keyboard, string word)
    {
        var indicesMap = new Dictionary<char, int>();

        for (var i = 0; i < keyboard.Length; i++)
        {
            indicesMap[keyboard[i]] = i;
        }

        var index = 0;
        var ans = 0;

        foreach (var letterIndex in word.Select(letter => indicesMap[letter]))
        {
            ans += Math.Abs(letterIndex - index);
            index = letterIndex;
        }

        return ans;
    }
}
