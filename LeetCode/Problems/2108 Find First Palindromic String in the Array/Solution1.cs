namespace LeetCode.Problems._2108_Find_First_Palindromic_String_in_the_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1173649529/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string FirstPalindrome(string[] words) => words.FirstOrDefault(IsPalindrome, "");
    private static bool IsPalindrome(string str) => str.SequenceEqual(str.Reverse());
}
