using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1673_Find_the_Most_Competitive_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/903249113/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int[] MostCompetitive(int[] nums, int k)
    {
        var list = new LinkedList<int>();

        var nodesToShift = new Queue<LinkedListNode<int>>();

        for (var i = 0; i < k; i++)
        {
            var num = nums[i];
            list.AddLast(num);

            if (i > 0 && list.Last!.Previous!.Value > num)
            {
                nodesToShift.Enqueue(list.Last.Previous);
            }
        }

        for (var i = k; i < nums.Length; i++)
        {
            if (nodesToShift.Count > 0)
            {
                var node = nodesToShift.Dequeue();
                list.Remove(node);
            }

            var num = nums[i];

            if (list.Count < k)
            {
                list.AddLast(num);
            }
            else if (list.Last!.Value > num)
            {
                list.Last!.Value = num;
            }

            if (list.Last!.Previous!.Value > list.Last.Value)
            {
                nodesToShift.Enqueue(list.Last.Previous);
            }
        }

        return list.ToArray();
    }
}
