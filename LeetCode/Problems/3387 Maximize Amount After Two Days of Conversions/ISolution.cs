namespace LeetCode.Problems._3387_Maximize_Amount_After_Two_Days_of_Conversions;

[PublicAPI]
public interface ISolution
{
    public double MaxAmount(string initialCurrency, IList<IList<string>> pairs1, double[] rates1, IList<IList<string>> pairs2, double[] rates2);
}
