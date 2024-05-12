using JetBrains.Annotations;

namespace LeetCode.Problems._0989_Add_to_Array_Form_of_Integer;

/// <summary>
/// https://leetcode.com/submissions/detail/898554601/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> AddToArrayForm(int[] num, int k)
    {
        var result = new List<int>();

        var index = num.Length - 1;

        var hasCarry = false;

        while (k > 0 || index >= 0)
        {
            var digit1 = index >= 0 ? num[index] : 0;
            var digit2 = k % 10;
            var resultDigit = digit1 + digit2 + (hasCarry ? 1 : 0);

            hasCarry = resultDigit >= 10;

            if (hasCarry)
            {
                resultDigit -= 10;
            }

            result.Insert(0, resultDigit);

            k /= 10;
            index--;
        }

        if (hasCarry)
        {
            result.Insert(0, 1);
        }

        return result;
    }
}
