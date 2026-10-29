namespace LeetCode.Problems._3508_Implement_Router;

[PublicAPI]
public interface IRouter
{
    bool AddPacket(int source, int destination, int timestamp);
    int[] ForwardPacket();
    int GetCount(int destination, int startTime, int endTime);
}
