using JetBrains.Annotations;

namespace LeetCode.Problems._0022_Generate_Parentheses;

[PublicAPI]
public interface ISolution
{
    IList<string> GenerateParenthesis(int n);
}
