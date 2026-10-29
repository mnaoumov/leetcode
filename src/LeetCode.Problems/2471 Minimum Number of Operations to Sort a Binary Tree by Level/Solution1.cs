namespace LeetCode.Problems._2471_Minimum_Number_of_Operations_to_Sort_a_Binary_Tree_by_Level;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-319/submissions/detail/842358474/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumOperations(TreeNode root)
    {
        var queue = new Queue<(TreeNode? node, int level)>();
        queue.Enqueue((root, 0));

        var levelValues = new List<int>();
        var lastLevel = 0;

        var result = 0;

        while (queue.Count > 0)
        {
            var (node, level) = queue.Dequeue();

            if (node == null)
            {
                continue;
            }

            if (level > lastLevel)
            {
                result += CalculateOperations(levelValues);
                levelValues.Clear();
                lastLevel = level;
            }

            levelValues.Add(node.val);

            queue.Enqueue((node.left, level + 1));
            queue.Enqueue((node.right, level + 1));
        }

        result += CalculateOperations(levelValues);

        return result;
    }

    private static int CalculateOperations(IList<int> values)
    {
        var sorted = values.OrderBy(x => x).ToArray();
        var valueIndexMap = values.Select((value, index) => (value, index)).ToDictionary(p => p.value, p => p.index);

        var result = 0;

        for (var i = 0; i < sorted.Length; i++)
        {
            var value = sorted[i];
            var index = valueIndexMap[value];

            if (index == i)
            {
                continue;
            }

            (values[i], values[index]) = (values[index], values[i]);
            valueIndexMap[values[i]] = i;
            valueIndexMap[values[index]] = index;
            result++;
        }

        return result;
    }
}
