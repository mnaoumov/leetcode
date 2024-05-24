using JetBrains.Annotations;

namespace LeetCode.Problems._1255_Maximum_Score_Words_Formed_by_Letters;

[PublicAPI]
public interface ISolution
{
    public int MaxScoreWords(string[] words, char[] letters, int[] score);
}
