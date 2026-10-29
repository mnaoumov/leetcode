namespace LeetCode.Problems._0266_Palindrome_Permutation;

/// <summary>
/// https://leetcode.com/problems/palindrome-permutation/submissions/1574011415/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanPermutePalindrome(string s) => s.GroupBy(letter => letter).Select(g => g.Count()).Count(count => count % 2 == 1) <= 1;
}
