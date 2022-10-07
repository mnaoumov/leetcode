namespace LeetCode;

public class SkipSolutionAttribute : Attribute
{
    public SkipSolutionAttribute(string reason)
    {
        Reason = reason;
    }

    public string Reason { get; }
}