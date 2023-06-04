using JetBrains.Annotations;

namespace LeetCode._0336_Palindrome_Pairs;

[PublicAPI]
public interface ISolution
{
    public IList<IList<int>> PalindromePairs(string[] words);
}
