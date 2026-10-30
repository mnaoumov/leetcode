namespace LeetCode.Base;

[AttributeUsage(AttributeTargets.Class)]
public sealed class SkipSolutionAttribute : Attribute
{
    public SkipSolutionAttribute(SkipSolutionReason reason)
    {
        Reason = reason;
    }

    public SkipSolutionReason Reason { get; }
}
