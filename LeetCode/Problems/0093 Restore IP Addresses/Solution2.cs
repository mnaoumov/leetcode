namespace LeetCode.Problems._0093_Restore_IP_Addresses;

/// <summary>
/// https://leetcode.com/submissions/detail/919081302/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<string> RestoreIpAddresses(string s)
    {
        var result = new List<string>();
        var parts = new List<int>();
        Backtrack(0);
        return result;

        void Backtrack(int i)
        {
            if (i == s.Length || parts.Count == 4)
            {
                if (i == s.Length && parts.Count == 4)
                {
                    result.Add(string.Join(".", parts));
                }

                return;
            }

            var part = 0;

            for (var j = i; j < Math.Min(i + 3, s.Length); j++)
            {
                var digit = s[j] - '0';
                part = part * 10 + digit;

                if (part > 255)
                {
                    break;
                }

                parts.Add(part);
                Backtrack(j + 1);
                parts.RemoveAt(parts.Count - 1);

                if (part == 0)
                {
                    break;
                }
            }
        }
    }
}
