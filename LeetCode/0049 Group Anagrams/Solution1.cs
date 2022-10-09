namespace LeetCode._0049_Group_Anagrams;

/// <summary>
/// https://leetcode.com/submissions/detail/196716802/
/// </summary>
public class Solution1 : ISolution
{
    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var dict = new Dictionary<string, IList<string>>();

        foreach (var str in strs)
        {
            var sorted = Sort(str);
            if (!dict.ContainsKey(sorted))
            {
                dict[sorted] = new List<string>();
            }

            dict[sorted].Add(str);
        }
        return dict.Values.ToArray();
    }

    private string Sort(string str)
    {
        return string.Join("", str.ToCharArray().OrderBy(x => x));
    }
}