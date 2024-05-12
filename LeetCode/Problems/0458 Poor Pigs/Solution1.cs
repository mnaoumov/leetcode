using JetBrains.Annotations;

namespace LeetCode._0458_Poor_Pigs;

/// <summary>
/// https://leetcode.com/submissions/detail/1086990192/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int PoorPigs(int buckets, int minutesToDie, int minutesToTest)
    {
        var tests = minutesToTest / minutesToDie;
        return (int) Math.Ceiling(Math.Log(buckets, tests + 1));
    }
}
