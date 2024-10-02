namespace LeetCode.Problems._1331_Rank_Transform_of_an_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1408812760/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] ArrayRankTransform(int[] arr)
    {
        var numRankMap = arr.Distinct().OrderBy(num => num).Select((num, index) => (num, index))
            .ToDictionary(x => x.num, x => x.index + 1);
        return arr.Select(num => numRankMap[num]).ToArray();
    }
}
