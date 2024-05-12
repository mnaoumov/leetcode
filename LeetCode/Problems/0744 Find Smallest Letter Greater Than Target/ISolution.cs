using JetBrains.Annotations;

namespace LeetCode.Problems._0744_Find_Smallest_Letter_Greater_Than_Target;

[PublicAPI]
public interface ISolution
{
    public char NextGreatestLetter(char[] letters, char target);
}
