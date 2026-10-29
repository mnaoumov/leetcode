using System.Globalization;

namespace LeetCode.Problems._0751_IP_to_CIDR;

/// <summary>
/// https://leetcode.com/problems/ip-to-cidr/submissions/2149178133/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    private const int MaxBit = 32;
    private const uint Base = 256;


    public IList<string> IpToCIDR(string ip, int n)
    {
        var start = ToUint32(ip);

        var ans = new List<string>();

        while (n > 0)
        {
            var bitsToTake = Math.Min(LowestBit(start), HighestBit(n) - 1);
            ans.Add($"{ToIpAddress(start)}/{32 - bitsToTake}");
            start += (uint) 1 << bitsToTake;
            n -= 1 << bitsToTake;
        }

        return ans;
    }

    private static string ToIpAddress(uint num)
    {
        const int partsCount = 4;

        var parts = new int[partsCount];

        for (var i = 0; i < partsCount; i++)
        {
            var part = num % Base;
            parts[^(1 + i)] = (int) part;
            num /= Base;
        }

        return string.Join(".", parts.Select(x => Convert.ToString(x, CultureInfo.InvariantCulture)));
    }

    private static int LowestBit(long num)
    {
        if (num == 0)
        {
            return MaxBit;
        }

        var ans = 0;

        while ((num & 1) == 0)
        {
            ans++;
            num >>= 1;
        }

        return ans;
    }

    private static int HighestBit(long num)
    {
        if (num == 0)
        {
            return MaxBit;
        }

        var ans = 0;

        while (num != 0)
        {
            ans++;
            num >>= 1;
        }

        return ans;
    }

    private static uint ToUint32(string ip)
    {
        var parts = ip.Split('.').Select(x => Convert.ToUInt32(x, CultureInfo.InvariantCulture)).ToArray();
        var @uint = parts.Aggregate((uint) 0, (a, b) => Base * a + b);
        return @uint;
    }
}
