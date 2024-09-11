namespace LeetCode.Problems._0564_Find_the_Closest_Palindrome;

/// <summary>
/// https://leetcode.com/submissions/detail/1367215832/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
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
        var isOddLength = (num & 1) == 1;

        return Enumerable.Range(-1, 3)
            .Select(diff => MakePalindrome(leftPartNum + diff, isOddLength))
            .Where(palindrome => palindrome != num)
            .OrderBy(palindrome => Math.Abs(palindrome - num))
            .ThenBy(palindrome => palindrome)
            .First()
            .ToString();
    }

    private static long MakePalindrome(long leftPartNum, bool isOddLength)
    {
        var leftPartStr = leftPartNum.ToString();

        if (leftPartStr.Length == 1)
        {
            return leftPartNum;
        }

        var symmetricPart = leftPartStr[..^(isOddLength ? 1 : 0)];
        var rightPart = string.Concat(symmetricPart.Reverse());
        var ansStr = leftPartStr + rightPart;
        return long.Parse(ansStr);
    }
}
