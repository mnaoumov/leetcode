using JetBrains.Annotations;

namespace LeetCode.Problems._3261_Count_Substrings_That_Satisfy_K_Constraint_II;

[PublicAPI]
public interface ISolution
{
    public long[] CountKConstraintSubstrings(string s, int k, int[][] queries);
}
