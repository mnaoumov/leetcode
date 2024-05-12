using JetBrains.Annotations;

namespace LeetCode.Problems._2942_Find_Words_Containing_Character;

[PublicAPI]
public interface ISolution
{
    public IList<int> FindWordsContaining(string[] words, char x);
}
