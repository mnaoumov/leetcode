using JetBrains.Annotations;

namespace LeetCode.Problems._2791_Count_Paths_That_Can_Form_a_Palindrome_in_a_Tree;

[PublicAPI]
public interface ISolution
{
    public long CountPalindromePaths(IList<int> parent, string s);
}
