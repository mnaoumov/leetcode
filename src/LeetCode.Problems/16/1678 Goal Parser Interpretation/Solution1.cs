namespace LeetCode.Problems._1678_Goal_Parser_Interpretation;

/// <seealso href="https://leetcode.com/submissions/detail/927554052/"/>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public string Interpret(string command) => command.Replace("()", "o").Replace("(al)", "al");
}
