using JetBrains.Annotations;

namespace LeetCode._2942_Find_Words_Containing_Character;

[PublicAPI]
public interface ISolution
{
    public IList<int> FindWordsContaining(string[] words, char x);
}
