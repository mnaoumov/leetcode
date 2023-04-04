using JetBrains.Annotations;

namespace LeetCode._1678_Goal_Parser_Interpretation;

/// <summary>
/// https://leetcode.com/submissions/detail/927554052/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string Interpret(string command) => command.Replace("()", "o").Replace("(al)", "al");
}
