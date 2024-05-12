using JetBrains.Annotations;

namespace LeetCode.Problems._2788_Split_Strings_by_Separator;

[PublicAPI]
public interface ISolution
{
    public IList<string> SplitWordsBySeparator(IList<string> words, char separator);
}
