namespace LeetCode.Problems._0774_Minimize_Max_Distance_to_Gas_Station;

/// <summary>
/// https://leetcode.com/problems/minimize-max-distance-to-gas-station/submissions/1794772377/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public double MinmaxGasDist(int[] stations, int k)
    {
        var n = stations.Length;
        var diffs = new int[n - 1];

        for (var i = 0; i < n - 1; i++)
        {
            diffs[i] = stations[i + 1] - stations[i];
        }

        var min = 0d;
        var max = (double) diffs.Max();

        while (max - min > 1e-6)
        {
            var mid = (min + max) / 2;

            if (diffs.Select(diff => (int) Math.Ceiling(diff / mid)).Sum() <= k + diffs.Length)
            {
                max = mid;
            }
            else
            {
                min = mid;
            }
        }

        return min;
    }
}
