using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0032_Longest_Valid_Parentheses;

/// <summary>
/// https://leetcode.com/submissions/detail/812700820/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution4 : ISolution
{
    private const char OpeningBracket = '(';
    private const char ClosingBracket = ')';

    public int LongestValidParentheses(string s)
    {
        var isValidCache = new bool?[s.Length, s.Length + 1];
        var longestValidLength = 0;

        for (int leftIndex = 0; leftIndex < s.Length - 1; leftIndex++)
        {
            for (int rightNonInclusiveIndex = s.Length; rightNonInclusiveIndex > leftIndex; rightNonInclusiveIndex--)
            {
                if (IsValidParentheses(leftIndex, rightNonInclusiveIndex))
                {
                    var length = rightNonInclusiveIndex - leftIndex;
                    if (length > longestValidLength)
                    {
                        longestValidLength = length;
                    }
                }
            }
        }

        return longestValidLength;

        bool IsValidParentheses(int leftIndex, int rightNonInclusiveIndex)
        {
            if (leftIndex == rightNonInclusiveIndex)
            {
                return true;
            }

            if (leftIndex > rightNonInclusiveIndex)
            {
                return false;
            }

            if (isValidCache[leftIndex, rightNonInclusiveIndex] is not { } isValid)
            {
                isValidCache[leftIndex, rightNonInclusiveIndex] = isValid = CalculateIsValidParentheses(leftIndex, rightNonInclusiveIndex);
            }

            return isValid;
        }

        bool CalculateIsValidParentheses(int leftIndex, int rightNonInclusiveIndex)
        {
            if (s[leftIndex] != OpeningBracket || s[rightNonInclusiveIndex - 1] != ClosingBracket)
            {
                return false;
            }

            for (var closingBracketIndex = leftIndex + 1; closingBracketIndex < rightNonInclusiveIndex; closingBracketIndex++)
            {
                if (s[closingBracketIndex] == ClosingBracket && IsValidParentheses(leftIndex + 1, closingBracketIndex) &&
                    IsValidParentheses(closingBracketIndex + 1, rightNonInclusiveIndex))
                {
                    return true;
                }
            }

            return false;
        }
    }
}