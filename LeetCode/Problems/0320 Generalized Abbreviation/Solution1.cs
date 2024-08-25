using JetBrains.Annotations;

namespace LeetCode.Problems._0320_Generalized_Abbreviation;

/// <summary>
/// https://leetcode.com/submissions/detail/1364204465/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<string> GenerateAbbreviations(string word)
    {
        return Get(0, false).ToArray();

        IEnumerable<string> Get(int index, bool shouldTakeLetter)
        {
            if (index == word.Length)
            {
                yield return "";
                yield break;
            }

            var letter = word[index];
            foreach (var next in Get(index + 1, false))
            {
                yield return letter + next;
            }

            if (!shouldTakeLetter)
            {
                for (var length = 1; length <= word.Length - index; length++)
                {
                    foreach (var next in Get(index + length, true))
                    {
                        yield return length + next;
                    }
                }
            }
        }
    }
}
