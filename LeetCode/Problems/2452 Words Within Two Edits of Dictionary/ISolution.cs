using JetBrains.Annotations;

namespace LeetCode.Problems._2452_Words_Within_Two_Edits_of_Dictionary;

[PublicAPI]
public interface ISolution
{
    public IList<string> TwoEditWords(string[] queries, string[] dictionary);
}
