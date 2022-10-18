using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0071_Simplify_Path;

/// <summary>
/// https://leetcode.com/submissions/detail/820369781/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string SimplifyPath(string path)
    {
        var parts = path.Split('/');

        var resultParts = new List<string>();

        foreach (var part in parts)
        {
            switch (part)
            {
                case "":
                case ".":
                    continue;
                case "..":
                    if (resultParts.Count > 0)
                    {
                        resultParts.RemoveAt(resultParts.Count - 1);
                    }

                    break;
                default:
                    resultParts.Add(part);
                    break;
            }
        }

        return "/" + string.Join('/', resultParts);
    }
}