using System.Text;

namespace LeetCode.Problems._0415_Add_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/934908582/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string AddStrings(string num1, string num2)
    {
        var index1 = num1.Length - 1;
        var index2 = num2.Length - 1;
        var sb = new StringBuilder();
        var carry = false;

        while (index1 >= 0 || index2 >= 0 || carry)
        {
            var digit1 = index1 >= 0 ? num1[index1] - '0' : 0;
            var digit2 = index2 >= 0 ? num2[index2] - '0' : 0;
            var digitSum = digit1 + digit2 + (carry ? 1 : 0);
            carry = digitSum >= 10;
            sb.Insert(0, digitSum - (carry ? 10 : 0));
            index1--;
            index2--;
        }

        return sb.ToString();
    }
}
