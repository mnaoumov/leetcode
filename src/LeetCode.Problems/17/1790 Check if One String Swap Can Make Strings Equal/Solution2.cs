namespace LeetCode.Problems._1790_Check_if_One_String_Swap_Can_Make_Strings_Equal;

/// <summary>
/// https://leetcode.com/submissions/detail/925209705/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool AreAlmostEqual(string s1, string s2)
    {
        if (s1 == s2)
        {
            return true;
        }

        var firstMismatchIndex = -1;
        var hasSwap = false;

        for (var i = 0; i < s1.Length; i++)
        {
            if (s1[i] == s2[i])
            {
                continue;
            }

            if (hasSwap)
            {
                return false;
            }

            if (firstMismatchIndex == -1)
            {
                firstMismatchIndex = i;
            }
            else if (s1[firstMismatchIndex] == s2[i] && s1[i] == s2[firstMismatchIndex])
            {
                hasSwap = true;
            }
            else
            {
                return false;
            }
        }

        return hasSwap;
    }
}
