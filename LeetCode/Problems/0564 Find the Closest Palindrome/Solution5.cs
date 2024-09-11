using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0564_Find_the_Closest_Palindrome;

/// <summary>
/// https://leetcode.com/submissions/detail/1367229180/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution5 : ISolution
{
    public string NearestPalindromic(string n)
    {
        if (n == "0")
        {
            return "1";
        }

        var num = long.Parse(n);
        var leftPartLength = (n.Length + 1) / 2;
        var leftPart = n[..leftPartLength];
        var leftPartNum = long.Parse(leftPart);
        var isOddLength = (n.Length & 1) == 1;

        return Enumerable.Range(-1, 3)
            .Select(diff =>
            {
                var anotherLeftPartNum = leftPartNum + diff;
                var lengthChanged = anotherLeftPartNum.ToString().Length != leftPart.Length;
                return MakePalindrome(anotherLeftPartNum, isOddLength ^ lengthChanged);
            })
            .Where(palindrome => palindrome != num)
            .OrderBy(palindrome => Math.Abs(palindrome - num))
            .ThenBy(palindrome => palindrome)
            .First()
            .ToString();
    }

    private static long MakePalindrome(long leftPartNum, bool isOddLength)
    {
        if (leftPartNum == 0)
        {
            return isOddLength ? 0 : 9;
        }

        var leftPartStr = leftPartNum.ToString();
        var symmetricPart = leftPartStr[..^(isOddLength ? 1 : 0)];
        var rightPart = string.Concat(symmetricPart.Reverse());
        var ansStr = leftPartStr + rightPart;
        return long.Parse(ansStr);
    }
}
