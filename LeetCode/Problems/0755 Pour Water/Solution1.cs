namespace LeetCode.Problems._0755_Pour_Water;

/// <summary>
/// https://leetcode.com/problems/pour-water/submissions/1972104857/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int[] PourWater(int[] heights, int volume, int k)
    {
        var ans = heights.ToArray();

        var n = heights.Length;

        var leftPq = new PriorityQueue<int, int>();
        var rightPq = new PriorityQueue<int, int>();

        for (var i = 0; i < k; i++)
        {
            leftPq.Enqueue(i, heights[i]);
        }

        for (var i = k + 1; i < n; i++)
        {
            rightPq.Enqueue(i, heights[i]);
        }

        for (var i = 0; i < volume; i++)
        {
            if (leftPq.Count > 0 && ans[leftPq.Peek()] < ans[k])
            {
                var leftIndex = leftPq.Dequeue();
                ans[leftIndex]++;
                leftPq.Enqueue(leftIndex, ans[leftIndex]);
            }
            else if (rightPq.Count > 0 && ans[rightPq.Peek()] < ans[k])
            {
                var rightIndex = rightPq.Dequeue();
                ans[rightIndex]++;
                rightPq.Enqueue(rightIndex, ans[rightIndex]);
            }
            else
            {
                ans[k]++;
            }
        }

        return ans;
    }
}
