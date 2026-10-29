namespace LeetCode.Problems._2138_Divide_a_String_Into_Groups_of_Size_k;

/// <summary>
/// https://leetcode.com/problems/divide-a-string-into-groups-of-size-k/submissions/1672079804/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string[] DivideString(string s, int k, char fill)
    {
        var list = new List<string>();
        var n = s.Length;
        for (var i = 0; i < n; i += k)
        {
            var j = Math.Min(i + k, n);
            var str = s[i..j];
            str = str.PadRight(k, fill);
            list.Add(str);
        }
        return list.ToArray();
    }
}
