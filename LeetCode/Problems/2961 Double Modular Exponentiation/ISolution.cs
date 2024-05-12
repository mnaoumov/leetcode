using JetBrains.Annotations;

namespace LeetCode._2961_Double_Modular_Exponentiation;

[PublicAPI]
public interface ISolution
{
    public IList<int> GetGoodIndices(int[][] variables, int target);
}
