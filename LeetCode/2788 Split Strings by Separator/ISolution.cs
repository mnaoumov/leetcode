using JetBrains.Annotations;

namespace LeetCode._2788_Split_Strings_by_Separator;

[PublicAPI]
public interface ISolution
{
    public IList<string> SplitWordsBySeparator(IList<string> words, char separator);
}
