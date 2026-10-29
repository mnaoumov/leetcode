namespace LeetCode.Problems._3412_Find_Mirror_Score_of_a_String;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-431/submissions/detail/1498013498/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CalculateScore(string s)
    {
        var ans = 0L;

        const int lettersCount = 26;

        var letterIndices = Enumerable.Range(0, lettersCount).Select(_ => new Stack<int>()).ToArray();

        for (var letterArrayIndex = 0; letterArrayIndex < s.Length; letterArrayIndex++)
        {
            var letter = s[letterArrayIndex];
            var letterAlphabetIndex = letter - 'a';
            var mirrorLetterAlphabetIndex = lettersCount - 1 - letterAlphabetIndex;

            if (letterIndices[mirrorLetterAlphabetIndex].Count > 0)
            {
                var mirrorLetterArrayIndex = letterIndices[mirrorLetterAlphabetIndex].Pop();
                ans += letterArrayIndex - mirrorLetterArrayIndex;
            }
            else
            {
                letterIndices[letterAlphabetIndex].Push(letterArrayIndex);
            }
        }

        return ans;
    }
}
