namespace LeetCode.Problems._2548_Maximum_Price_to_Fill_a_Bag;

/// <summary>
/// https://leetcode.com/submissions/detail/887112773/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public double MaxPrice(int[][] items, int capacity) => MaxPrice(items.Select(Item.FromArray), capacity);

    private static double MaxPrice(IEnumerable<Item> items, int capacity)
    {
        var result = 0d;

        foreach (var item in items.OrderByDescending(item => item.PricePerKilo))
        {
            if (capacity == 0)
            {
                break;
            }

            var weightAvailable = Math.Min(item.Weight, capacity);
            capacity -= weightAvailable;
            result += 1d * weightAvailable / item.Weight * item.Price;
        }

        return capacity == 0 ? result : -1;
    }

    private record Item(int Price, int Weight)
    {
        public double PricePerKilo => 1d * Price / Weight;
        public static Item FromArray(int[] arr) => new(arr[0], arr[1]);
    }
}
