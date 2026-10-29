namespace LeetCode.Problems._3492_Maximum_Containers_on_a_Ship;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-442/problems/maximum-containers-on-a-ship/submissions/1582816409/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxContainers(int n, int w, int maxWeight) => Math.Min(n * n, (int) Math.Floor(1d * maxWeight / w));
}
