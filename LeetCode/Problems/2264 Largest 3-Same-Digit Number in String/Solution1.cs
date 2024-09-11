namespace LeetCode.Problems._2264_Largest_3_Same_Digit_Number_in_String;

/// <summary>
/// https://leetcode.com/submissions/detail/1111828842/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string LargestGoodInteger(string num)
    {
        var ans = "";
        for (var i = 0; i < num.Length - 2; i++)
        {
            if (num[i + 1] != num[i] || num[i + 2] != num[i])
            {
                continue;
            }

            var str = num[i..(i + 3)];
            if (string.CompareOrdinal(str, ans) > 0)
            {
                ans = str;
            }
        }

        return ans;
    }
}
