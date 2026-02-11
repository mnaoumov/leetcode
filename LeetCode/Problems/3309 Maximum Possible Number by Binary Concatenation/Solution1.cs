
namespace LeetCode.Problems._3309_Maximum_Possible_Number_by_Binary_Concatenation;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-418/submissions/detail/1413264708/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxGoodNumber(int[] nums)
    {
        var binaries = nums.Select(num => Convert.ToString(num, 2)).ToArray();
        var ans = 0;
        // ReSharper disable once LoopCanBeConvertedToQuery
        foreach (var permutation in Permutations(binaries))
        {
            var concat = string.Concat(permutation);
            var num = Convert.ToInt32(concat, 2);
            ans = Math.Max(ans, num);
        }

        return ans;
    }

    private static IEnumerable<IEnumerable<T>> Permutations<T>(T[] items)
    {
        if (items.Length == 0)
        {
            yield return Enumerable.Empty<T>();
            yield break;
        }

        var tail = items.Skip(1).ToArray();
        foreach (var tailPermutation in Permutations(tail))
        {
            var list = tailPermutation.ToList();
            for (var i = 0; i <= list.Count; i++)
            {
                list.Insert(i, items[0]);
                yield return list.ToArray();
                list.RemoveAt(i);
            }
        }
    }
}
