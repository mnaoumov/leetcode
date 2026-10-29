using System.Text.RegularExpressions;

namespace LeetCode.Problems._3606_Coupon_Code_Validator;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-457/problems/coupon-code-validator/submissions/1687855802/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive)
    {
        var n = code.Length;
        var categories = new[] { "electronics", "grocery", "pharmacy", "restaurant" };

        return Enumerable.Range(0, n)
            .Select(i => new Coupon(code[i], Array.IndexOf(categories, businessLine[i]), isActive[i]))
            .Where(c => Regex.IsMatch(c.Code, "^[a-zA-z0-9_]+$"))
            .Where(c => c.BusinessLineIndex != -1)
            .Where(c => c.IsActive)
            .OrderBy(c => c.BusinessLineIndex)
            .ThenBy(c => c.Code)
            .Select(c => c.Code)
            .ToArray();
    }

    private record Coupon(string Code, int BusinessLineIndex, bool IsActive);
}
