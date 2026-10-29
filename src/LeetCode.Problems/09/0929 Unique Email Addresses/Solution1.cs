namespace LeetCode.Problems._0929_Unique_Email_Addresses;

/// <summary>
/// https://leetcode.com/submissions/detail/924478042/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumUniqueEmails(string[] emails)
    {
        var set = new HashSet<string>();
        var result = 0;

        foreach (var email in emails)
        {
            var parts = email.Split('@');
            var localName = parts[0];
            var domain = parts[1];

            var parts2 = localName.Split('+');
            localName = parts2[0];

            localName = localName.Replace(".", "");

            var key = $"{localName}@{domain}";

            if (set.Add(key))
            {
                result++;
            }
        }

        return result;
    }
}
