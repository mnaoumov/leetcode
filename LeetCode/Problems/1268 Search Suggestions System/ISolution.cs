namespace LeetCode.Problems._1268_Search_Suggestions_System;

[PublicAPI]
public interface ISolution
{
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord);
}
