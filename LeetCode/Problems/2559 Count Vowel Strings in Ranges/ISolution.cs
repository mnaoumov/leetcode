using JetBrains.Annotations;

namespace LeetCode.Problems._2559_Count_Vowel_Strings_in_Ranges;

[PublicAPI]
public interface ISolution
{
    public int[] VowelStrings(string[] words, int[][] queries);
}
