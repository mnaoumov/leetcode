namespace LeetCode.Problems._1007_Minimum_Domino_Rotations_For_Equal_Row;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinDominoRotations(int[] tops, int[] bottoms)
    {
        var n = tops.Length;

        var ans = int.MaxValue;

        for (var value = 1; value <= 6; value++)
        {
            var swapsWithValueOnTop = 0;
            var swapsWithValueOnBottom = 0;
            var impossible = false;

            for (var i = 0; i < n; i++)
            {
                if (tops[i] != value && bottoms[i] != value)
                {
                    impossible = true;
                    break;
                }

                if (tops[i] == value && bottoms[i] == value)
                {
                    continue;
                }

                if (tops[i] == value)
                {
                    swapsWithValueOnBottom++;
                }
                else
                {
                    swapsWithValueOnTop++;
                }
            }

            if (impossible)
            {
                continue;
            }

            ans = Math.Min(ans, Math.Min(swapsWithValueOnTop, swapsWithValueOnBottom));
        }

        if (ans == int.MaxValue)
        {
            ans = -1;
        }

        return ans;
    }
}
