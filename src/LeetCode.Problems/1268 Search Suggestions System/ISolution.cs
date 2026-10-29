namespace LeetCode.Problems._1268_Search_Suggestions_System;

[PublicAPI]
public interface ISolution
{
    IList<IList<string>> SuggestedProducts(string[] products, string searchWord);
}
