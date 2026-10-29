namespace LeetCode.Problems._1750_Minimum_Length_of_String_After_Deleting_Similar_Ends;

/// <summary>
/// https://leetcode.com/submissions/detail/1194132987/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumLength(string s)
    {
        var start = 0;
        var end = s.Length - 1;

        while (start < end && s[start] == s[end])
        {
            var letter = s[start];

            while (start < end && s[start] == letter)
            {
                start++;
            }

            while (start <= end && s[end] == letter)
            {
                end--;
            }
        }

        return end - start + 1;
    }
}
