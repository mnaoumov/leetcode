namespace LeetCode;

[AttributeUsage(AttributeTargets.Class)]
public class SkipSolutionAttribute : Attribute
{
    public SkipSolutionAttribute(SkipSolutionReason reason)
    {
        Reason = reason;
    }

    public SkipSolutionReason Reason { get; }
}
