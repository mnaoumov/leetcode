using JetBrains.Annotations;

namespace LeetCode.Problems._0946_Validate_Stack_Sequences;

[PublicAPI]
public interface ISolution
{
    public bool ValidateStackSequences(int[] pushed, int[] popped);
}
