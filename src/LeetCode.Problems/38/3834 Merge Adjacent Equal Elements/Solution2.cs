namespace LeetCode.Problems._3834_Merge_Adjacent_Equal_Elements;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-488/problems/merge-adjacent-equal-elements/submissions/1911969146/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<long> MergeAdjacent(int[] nums)
    {
        var list = new LinkedList<long>(nums.Select(num => (long) num));

        var node = list.First;

        while (node?.Next != null)
        {
            if (node.Value == node.Next.Value)
            {
                node.Value *= 2;
                list.Remove(node.Next);
                if (node.Previous != null)
                {
                    node = node.Previous;
                }
            }
            else
            {
                node = node.Next;
            }
        }

        return list.ToArray();
    }
}
