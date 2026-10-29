namespace LeetCode.Problems._1784_Check_if_Binary_String_Has_at_Most_One_Segment_of_Ones;

/// <summary>
/// https://leetcode.com/problems/check-if-binary-string-has-at-most-one-segment-of-ones/submissions/1939290566/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CheckOnesSegment(string s)
    {
        var isOnePrefix = true;

        foreach (var symbol in s)
        {
            if (symbol == '0')
            {
                isOnePrefix = false;
            }
            else if (!isOnePrefix)
            {
                return false;
            }
        }

        return true;
    }
}
