namespace LeetCode.Problems._2053_Kth_Distinct_String_in_an_Array;

/// <summary>
/// https://leetcode.com/problems/kth-distinct-string-in-an-array/submissions/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string KthDistinct(string[] arr, int k)
    {
        var distinctMap = new Dictionary<string, bool>();

        foreach (var str in arr)
        {
            if (!distinctMap.TryAdd(str, true))
            {
                distinctMap[str] = false;
            }
        }

        var index = 0;

        foreach (var str in arr)
        {
            if (!distinctMap[str])
            {
                continue;
            }

            index++;

            if (index == k)
            {
                return str;
            }
        }

        return "";
    }
}
