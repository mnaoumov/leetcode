using JetBrains.Annotations;

namespace LeetCode.Problems._1642_Furthest_Building_You_Can_Reach;

/// <summary>
/// https://leetcode.com/submissions/detail/1179971656/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int FurthestBuilding(int[] heights, int bricks, int ladders)
    {
        var ladderJumps = new PriorityQueue<int, int>();
        var brickJumpsSum = 0;

        for (var i = 1; i < heights.Length; i++)
        {
            var jump = heights[i] - heights[i - 1];

            if (jump <= 0)
            {
                continue;
            }

            ladderJumps.Enqueue(jump, jump);

            if (ladderJumps.Count <= ladders)
            {
                continue;
            }

            var minJump = ladderJumps.Dequeue();
            brickJumpsSum += minJump;

            if (brickJumpsSum > bricks)
            {
                return i - 1;
            }
        }

        return heights.Length - 1;
    }
}
