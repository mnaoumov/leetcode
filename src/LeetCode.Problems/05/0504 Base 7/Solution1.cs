using System.Text;

namespace LeetCode.Problems._0504_Base_7;

/// <seealso href="https://leetcode.com/submissions/detail/926235280/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string ConvertToBase7(int num)
    {
        switch (num)
        {
            case 0:
                return "0";
            case < 0:
                return $"-{ConvertToBase7(-num)}";
            case > 0:
                var sb = new StringBuilder();

                while (num > 0)
                {
                    sb.Insert(0, num % 7);
                    num /= 7;
                }

                return sb.ToString();
        }
    }
}
