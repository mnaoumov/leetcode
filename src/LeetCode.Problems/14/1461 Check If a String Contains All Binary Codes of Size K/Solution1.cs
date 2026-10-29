namespace LeetCode.Problems._1461_Check_If_a_String_Contains_All_Binary_Codes_of_Size_K;

/// <summary>
/// https://leetcode.com/problems/check-if-a-string-contains-all-binary-codes-of-size-k/submissions/1927926401/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool HasAllCodes(string s, int k)
    {
        var set = new HashSet<string>();

        var desiredCount = 1 << k;

        for (var i = 0; i <= s.Length - k; i++)
        {
            set.Add(s[i..(i + k)]);

            if (set.Count == desiredCount)
            {
                return true;
            }
        }

        return false;
    }
}
