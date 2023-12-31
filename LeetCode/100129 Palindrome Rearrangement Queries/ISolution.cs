using JetBrains.Annotations;

namespace LeetCode._100129_Palindrome_Rearrangement_Queries;

[PublicAPI]
public interface ISolution
{
    public bool[] CanMakePalindromeQueries(string s, int[][] queries);
}
