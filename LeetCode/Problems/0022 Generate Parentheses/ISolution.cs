using JetBrains.Annotations;

namespace LeetCode._0022_Generate_Parentheses;

[PublicAPI]
public interface ISolution
{
    IList<string> GenerateParenthesis(int n);
}
