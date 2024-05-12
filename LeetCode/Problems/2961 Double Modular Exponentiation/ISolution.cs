using JetBrains.Annotations;

namespace LeetCode.Problems._2961_Double_Modular_Exponentiation;

[PublicAPI]
public interface ISolution
{
    public IList<int> GetGoodIndices(int[][] variables, int target);
}
