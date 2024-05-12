using JetBrains.Annotations;

namespace LeetCode._2446_Determine_if_Two_Events_Have_Conflict;

[PublicAPI]
public interface ISolution
{
    public bool HaveConflict(string[] event1, string[] event2);
}
