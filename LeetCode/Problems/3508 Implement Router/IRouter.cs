namespace LeetCode.Problems._3508_Implement_Router;

[PublicAPI]
public interface IRouter
{
    public bool AddPacket(int source, int destination, int timestamp);
    public int[] ForwardPacket();
    public int GetCount(int destination, int startTime, int endTime);
}
