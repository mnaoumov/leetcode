using JetBrains.Annotations;

namespace LeetCode.Problems._2828_Check_if_a_String_Is_an_Acronym_of_Words;

[PublicAPI]
public interface ISolution
{
    public bool IsAcronym(IList<string> words, string s);
}
