namespace LeetCode.Problems._2418_Sort_the_People;

/// <summary>
/// https://leetcode.com/submissions/detail/1328997528/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string[] SortPeople(string[] names, int[] heights) => names.Zip(heights, (name, height) => (name, height))
        .OrderByDescending(x => x.height).Select(x => x.name).ToArray();
}
