namespace LeetCode.Base;

[AttributeUsage(AttributeTargets.Class)]
internal sealed class SkipSolutionAttribute : Attribute
{
    public SkipSolutionAttribute(SkipSolutionReason reason)
    {
        Reason = reason;
    }

    public SkipSolutionReason Reason { get; }
}
