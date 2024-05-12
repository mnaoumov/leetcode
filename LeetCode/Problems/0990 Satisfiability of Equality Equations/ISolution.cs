using JetBrains.Annotations;

namespace LeetCode.Problems._0990_Satisfiability_of_Equality_Equations;

[PublicAPI]
public interface ISolution
{
    public bool EquationsPossible(string[] equations);
}
