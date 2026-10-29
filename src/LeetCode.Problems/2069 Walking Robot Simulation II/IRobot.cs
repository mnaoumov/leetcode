namespace LeetCode.Problems._2069_Walking_Robot_Simulation_II;

[PublicAPI]
public interface IRobot
{
#pragma warning disable CA1716
    void Step(int num);
#pragma warning restore CA1716
    int[] GetPos();
    string GetDir();
}
