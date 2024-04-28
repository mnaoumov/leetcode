using System.Collections;
using JetBrains.Annotations;

namespace LeetCode._3133_Minimum_Array_End;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-395/submissions/detail/1243801339/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MinEnd(int n, int x)
    {
        const int longBitCount = 64;
        var bitArray = new BitArray(longBitCount);
        var ans = 0L;

        var index = 0;

        while (x > 0)
        {
            var lastBit = (x & 1) == 1;
            bitArray.Set(index, lastBit);
            index++;
            x >>= 1;
        }

        var ansBit = 0;

        var shift = n - 1;

        while (shift > 0)
        {
            var lastBit = (shift & 1) == 1;
            shift >>= 1;
            while (bitArray.Get(ansBit))
            {
                ansBit++;
            }
            bitArray.Set(ansBit, lastBit);
            ansBit++;
        }

        for (var i = 0; i < longBitCount; i++)
        {
            if (bitArray.Get(i))
            {
                ans |= 1L << i;
            }
        }

        return ans;
    }
}
