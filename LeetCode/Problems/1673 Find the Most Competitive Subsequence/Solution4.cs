using JetBrains.Annotations;

namespace LeetCode.Problems._1673_Find_the_Most_Competitive_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/903265684/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int[] MostCompetitive(int[] nums, int k)
    {
        var list = new LinkedList<int>();

        var nodesToShift = new LinkedList<LinkedListNode<int>>();

        for (var i = 0; i < k; i++)
        {
            var num = nums[i];
            list.AddLast(num);

            if (i > 0 && list.Last!.Previous!.Value > num)
            {
                nodesToShift.AddLast(list.Last.Previous);
            }
        }

        for (var i = k; i < nums.Length; i++)
        {
            if (nodesToShift.Count > 0)
            {
                var node = nodesToShift.First!.Value;
                nodesToShift.RemoveFirst();

                if (node is { Previous: not null, Next: not null } && node.Previous.Value > node.Next.Value)
                {
                    nodesToShift.AddFirst(node.Previous);
                }

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

            if (k > 1 && list.Last!.Previous!.Value > list.Last.Value)
            {
                nodesToShift.AddLast(list.Last.Previous);
            }
        }

        return list.ToArray();
    }
}
