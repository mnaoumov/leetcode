namespace LeetCode.Problems._0898_Bitwise_ORs_of_Subarrays;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int SubarrayBitwiseORs(int[] arr)
    {
        var previousOrs = new HashSet<int>();
        var allOrs = new HashSet<int>();

        foreach (var num in arr)
        {
            var ors = new HashSet<int>();

            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var or in previousOrs)
            {
                var newOr = or | num;
                ors.Add(newOr);
            }

            ors.Add(num);
            previousOrs = ors;
            allOrs.UnionWith(ors);
        }

        return allOrs.Count;
    }
}