namespace LeetCode.Problems._2070_Most_Beautiful_Item_for_Each_Query;

/// <summary>
/// https://leetcode.com/submissions/detail/1450066572/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] MaximumBeauty(int[][] items, int[] queries)
    {
        var priceToMaxBeautyMap = items.Select(arr => new Item(arr[0], arr[1])).GroupBy(x => x.Price)
            .ToDictionary(g => g.Key, g => g.Max(item => item.Beauty));

        var sortedPrices = priceToMaxBeautyMap.Keys.OrderBy(x => x).ToArray();

        for (var i = 1; i < sortedPrices.Length; i++)
        {
            priceToMaxBeautyMap[sortedPrices[i]] = Math.Max(priceToMaxBeautyMap[sortedPrices[i]],
                priceToMaxBeautyMap[sortedPrices[i - 1]]);
        }

        return queries.Select(query =>
        {
            var index = Array.BinarySearch(sortedPrices, query);
            if (index < 0)
            {
                index = ~index - 1;
            }

            return index < 0 ? 0 : priceToMaxBeautyMap[sortedPrices[index]];
        }).ToArray();
    }

    private record Item(int Price, int Beauty);
}
