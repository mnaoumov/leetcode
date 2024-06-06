using JetBrains.Annotations;

namespace LeetCode.Problems._1002_Find_Common_Characters;

[PublicAPI]
public interface ISolution
{
    public IList<string> CommonChars(string[] words);
}
