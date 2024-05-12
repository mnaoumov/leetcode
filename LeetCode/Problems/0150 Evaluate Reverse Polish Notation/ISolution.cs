using JetBrains.Annotations;

namespace LeetCode._0150_Evaluate_Reverse_Polish_Notation;

[PublicAPI]
public interface ISolution
{
    public int EvalRPN(string[] tokens);
}
