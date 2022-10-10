namespace LeetCode._0058_Length_of_Last_Word;

/// <summary>
/// https://leetcode.com/submissions/detail/819454842/
/// </summary>
public class Solution1 : ISolution
{
    public int LengthOfLastWord(string s)
    {
        var result = 0;
        var hasWordEnded = false;

        foreach (var letter in s)
        {
            if (letter == ' ')
            {
                hasWordEnded = true;
            }
            else
            {
                if (hasWordEnded)
                {
                    hasWordEnded = false;
                    result = 0;
                }

                result++;
            }
        }

        return result;
    }
}