namespace LeetCode.Problems._3675_Minimum_Operations_to_Transform_String;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-466/problems/minimum-operations-to-transform-string/submissions/1762073270/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinOperations(string s)
    {
        const int lettersCount = 26;
        const char minLetter = 'a';
        var minIndex = s.Select(letter => letter == minLetter ? lettersCount : letter - minLetter).Min();
        return lettersCount - minIndex;
    }
}
