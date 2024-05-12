using JetBrains.Annotations;

namespace LeetCode._0165_Compare_Version_Numbers;

/// <summary>
/// https://leetcode.com/submissions/detail/874657524/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CompareVersion(string version1, string version2)
    {
        var parts1 = version1.Split('.').Select(int.Parse).ToArray();
        var parts2 = version2.Split('.').Select(int.Parse).ToArray();

        for (var i = 0; i < Math.Max(parts1.Length, parts2.Length); i++)
        {
            var revision1 = parts1.ElementAtOrDefault(i);
            var revision2 = parts2.ElementAtOrDefault(i);

            if (revision1 < revision2)
            {
                return -1;
            }

            if (revision1 > revision2)
            {
                return 1;
            }
        }

        return 0;
    }
}
