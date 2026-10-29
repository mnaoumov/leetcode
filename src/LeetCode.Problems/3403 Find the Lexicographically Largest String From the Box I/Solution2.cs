namespace LeetCode.Problems._3403_Find_the_Lexicographically_Largest_String_From_the_Box_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-430/submissions/detail/1491153096/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public string AnswerString(string word, int numFriends)
    {
        var length = word.Length - numFriends + 1;

        var ansStartIndex = 0;

        for (var startIndex = 1; startIndex <= word.Length - length; startIndex++)
        {
            for (var partIndex = 0; partIndex < length; partIndex++)
            {
                var ansLetter = word[ansStartIndex + partIndex];
                var letter = word[startIndex + partIndex];

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

        return word[ansStartIndex..(ansStartIndex + length)];
    }
}