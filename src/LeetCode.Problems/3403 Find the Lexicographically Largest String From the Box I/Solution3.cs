namespace LeetCode.Problems._3403_Find_the_Lexicographically_Largest_String_From_the_Box_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-430/submissions/detail/1491163715/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public string AnswerString(string word, int numFriends)
    {
        var length = word.Length - numFriends + 1;

        var ansStartIndex = 0;

        for (var startIndex = 1; startIndex < word.Length; startIndex++)
        {
            for (var partIndex = 0; partIndex < length; partIndex++)
            {
                var ansLetter = GetLetter(ansStartIndex + partIndex);
                var letter = GetLetter(startIndex + partIndex);

                if (ansLetter < letter)
                {
                    ansStartIndex = startIndex;
                    break;
                }
                if (ansLetter > letter)
                {
                    break;
                }
            }
        }

        return word[ansStartIndex..Math.Min(ansStartIndex + length, word.Length)];

        char GetLetter(int index) => 0 <= index && index < word.Length ? word[index] : char.MinValue;
    }
}