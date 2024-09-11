namespace LeetCode.Problems._0022_Generate_Parentheses;

/// <summary>
/// https://leetcode.com/submissions/detail/810831394/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    private readonly Dictionary<int, string[]> _cache = new();

    public IList<string> GenerateParenthesis(int n)
    {
        if (!_cache.TryGetValue(n, out var result))
        {
            result = _cache[n] = GenerateParenthesisImpl(n).ToArray();
        }

        return result;
    }

    private IEnumerable<string> GenerateParenthesisImpl(int n)
    {
        if (n == 0)
        {
            yield return "";
            yield break;
        }

        for (var i = 0; i < n; i++)
        {
            var leftParts = GenerateParenthesis(i);
            var rightParts = GenerateParenthesis(n - 1 - i);

            foreach (var leftPart in leftParts)
            {
                foreach (var rightPart in rightParts)
                {
                    yield return $"({leftPart}){rightPart}";
                }
            }
        }
    }
}
