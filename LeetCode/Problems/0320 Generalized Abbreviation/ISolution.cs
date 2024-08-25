using JetBrains.Annotations;

namespace LeetCode.Problems._0320_Generalized_Abbreviation;

[PublicAPI]
public interface ISolution
{
    public IList<string> GenerateAbbreviations(string word);
}
