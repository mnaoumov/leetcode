using JetBrains.Annotations;

namespace LeetCode._1603_Design_Parking_System;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IParkingSystem Create(int big, int medium, int small)
    {
        return new ParkingSystem1(big, medium, small);
    }
}
