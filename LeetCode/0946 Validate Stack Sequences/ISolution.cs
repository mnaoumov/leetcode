using JetBrains.Annotations;

namespace LeetCode._0946_Validate_Stack_Sequences;

[PublicAPI]
public interface ISolution
{
    public bool ValidateStackSequences(int[] pushed, int[] popped);
}
