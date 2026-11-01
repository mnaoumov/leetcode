namespace LeetCode.Problems._2549_Count_Distinct_Numbers_on_Board;

/// <seealso href="https://leetcode.com/contest/weekly-contest-330/submissions/detail/887152579/"/>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int DistinctIntegers(int n) => n == 1 ? 1 : n - 1;
}
