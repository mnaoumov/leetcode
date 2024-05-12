using JetBrains.Annotations;

namespace LeetCode._2515_Shortest_Distance_to_Target_String_in_a_Circular_Array;

[PublicAPI]
public interface ISolution
{
    public int ClosetTarget(string[] words, string target, int startIndex);
}
