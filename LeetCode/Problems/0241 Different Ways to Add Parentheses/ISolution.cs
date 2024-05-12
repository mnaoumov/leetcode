using JetBrains.Annotations;

namespace LeetCode.Problems._0241_Different_Ways_to_Add_Parentheses;

[PublicAPI]
public interface ISolution
{
    public IList<int> DiffWaysToCompute(string expression);
}
