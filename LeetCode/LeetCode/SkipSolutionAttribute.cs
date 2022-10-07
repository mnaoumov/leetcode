namespace LeetCode;

public class SkipSolutionAttribute : Attribute
{
    public SkipSolutionAttribute(SkipSolutionReason reason)
    {
        Reason = reason;
    }

    public SkipSolutionReason Reason { get; }
}