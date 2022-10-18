using JetBrains.Annotations;

namespace LeetCode._0068_Text_Justification;

[PublicAPI]
public interface ISolution
{
    public IList<string> FullJustify(string[] words, int maxWidth);
}