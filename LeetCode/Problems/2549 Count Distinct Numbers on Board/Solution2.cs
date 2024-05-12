using JetBrains.Annotations;

namespace LeetCode._2549_Count_Distinct_Numbers_on_Board;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-330/submissions/detail/887152579/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int DistinctIntegers(int n) => n == 1 ? 1 : n - 1;
}
