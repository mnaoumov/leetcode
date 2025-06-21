namespace LeetCode.Problems._1432_Max_Difference_You_Can_Get_From_Changing_an_Integer;

/// <summary>
/// https://leetcode.com/problems/max-difference-you-can-get-from-changing-an-integer/submissions/1664484011/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxDiff(int num)
    {
        var str = num.ToString();

        var nums = new List<int> { num };

        for (var x = 0; x < 10; x++)
        {
            for (var y = 0; y < 10; y++)
            {
                var newStr = str.Replace(x.ToString(), y.ToString());

                if (newStr[0] == '0')
                {
                    continue;
                }

                nums.Add(int.Parse(newStr));
            }
        }

        return nums.Max() - nums.Min();
    }
}
