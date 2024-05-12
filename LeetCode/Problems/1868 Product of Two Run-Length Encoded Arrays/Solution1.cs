using JetBrains.Annotations;

namespace LeetCode.Problems._1868_Product_of_Two_Run_Length_Encoded_Arrays;

/// <summary>
/// https://leetcode.com/submissions/detail/945205030/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> FindRLEArray(int[][] encoded1, int[][] encoded2)
    {
        var ans = new List<IList<int>>();

        var expandedAnsIndex = 0;
        var encodedIndex1 = -1;
        var encodedIndex2 = -1;
        var nextExpandedIndex1 = 0;
        var nextExpandedIndex2 = 0;

        while (true)
        {
            if (nextExpandedIndex1 == expandedAnsIndex)
            {
                encodedIndex1++;

                if (encodedIndex1 == encoded1.Length)
                {
                    break;
                }

                nextExpandedIndex1 += encoded1[encodedIndex1][1];
            }

            if (nextExpandedIndex2 == expandedAnsIndex)
            {
                encodedIndex2++;

                if (encodedIndex2 == encoded2.Length)
                {
                    break;
                }

                nextExpandedIndex2 += encoded2[encodedIndex2][1];
            }

            var num1 = encoded1[encodedIndex1][0];
            var num2 = encoded2[encodedIndex2][0];
            var length = Math.Min(nextExpandedIndex1, nextExpandedIndex2) - expandedAnsIndex;
            var product = num1 * num2;

            if (ans.Count > 0 && ans[^1][0] == product)
            {
                ans[^1][1] += length;
            }
            else
            {
                ans.Add(new[] { product, length });
            }

            expandedAnsIndex += length;
        }

        return ans;
    }
}
