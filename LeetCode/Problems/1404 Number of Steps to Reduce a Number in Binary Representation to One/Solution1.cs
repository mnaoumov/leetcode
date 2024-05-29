using JetBrains.Annotations;
using System.Text;

namespace LeetCode.Problems._1404_Number_of_Steps_to_Reduce_a_Number_in_Binary_Representation_to_One;

/// <summary>
/// https://leetcode.com/submissions/detail/1270945025/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumSteps(string s)
    {
        var sb = new StringBuilder(s);
        var ans = 0;

        while (sb.Length > 1)
        {
            ans++;
            if (sb[^1] == '0')
            {
                sb.Remove(sb.Length - 1, 1);
            }
            else
            {
                var j = sb.Length - 1;
                while (j >= 0 && sb[j] == '1')
                {
                    sb[j] = '0';
                    j--;
                }

                if (j < 0)
                {
                    sb.Insert(0, '1');
                }
                else
                {
                    sb[j] = '1';
                }
            }
        }

        return ans;
    }
}
