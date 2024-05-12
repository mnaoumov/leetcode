using JetBrains.Annotations;

namespace LeetCode._2516_Take_K_of_Each_Character_From_Left_and_Right;

/// <summary>
/// https://leetcode.com/submissions/detail/865487489/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int TakeCharacters(string s, int k)
    {
        var n = s.Length;

        var aLeftIndices = new int[k + 1];
        var bLeftIndices = new int[k + 1];
        var cLeftIndices = new int[k + 1];

        var aLeftCount = 0;
        var bLeftCount = 0;
        var cLeftCount = 0;

        for (var left = 0; left < n; left++)
        {
            switch (s[left])
            {
                case 'a':
                    if (aLeftCount < k)
                    {
                        aLeftCount++;
                        aLeftIndices[aLeftCount] = left + 1;
                    }

                    break;
                case 'b':
                    if (bLeftCount < k)
                    {
                        bLeftCount++;
                        bLeftIndices[bLeftCount] = left + 1;
                    }

                    break;

                case 'c':
                    if (cLeftCount < k)
                    {
                        cLeftCount++;
                        cLeftIndices[cLeftCount] = left + 1;
                    }

                    break;
            }
        }

        if (aLeftIndices[k] == 0 || bLeftIndices[k] == 0 || cLeftIndices[k] == 0)
        {
            return -1;
        }

        var result = n;

        var aRightCount = 0;
        var bRightCount = 0;
        var cRightCount = 0;

        for (var right = n - 1; right >= n - result; right--)
        {
            result = Math.Min(result,
                n - 1 - right + new[]
                {
                    aLeftIndices[k - aRightCount], bLeftIndices[k - bRightCount], cLeftIndices[k - cRightCount]
                }.Max());

            switch (s[right])
            {
                case 'a':
                    if (aRightCount < k)
                    {
                        aRightCount++;
                    }

                    break;
                case 'b':
                    if (bRightCount < k)
                    {
                        bRightCount++;
                    }

                    break;

                case 'c':
                    if (cRightCount < k)
                    {
                        cRightCount++;
                    }

                    break;
            }

        }

        return result;
    }
}
