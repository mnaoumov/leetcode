namespace LeetCode.Problems._1207_Unique_Number_of_Occurrences;

/// <summary>
/// https://leetcode.com/submissions/detail/852503461/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool UniqueOccurrences(int[] arr)
    {
        var countsMap = new Dictionary<int, int>();

        foreach (var num in arr)
        {
            countsMap[num] = countsMap.GetValueOrDefault(num) + 1;
        }

        var countsSet = new HashSet<int>();
        return countsMap.Values.All(count => countsSet.Add(count));
    }
}
