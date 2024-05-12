using JetBrains.Annotations;

namespace LeetCode.Problems._2836_Maximize_Value_of_Function_in_a_Ball_Passing_Game;

[PublicAPI]
public interface ISolution
{
    public long GetMaxFunctionValue(IList<int> receiver, long k);
}
