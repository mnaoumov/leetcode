using JetBrains.Annotations;

namespace LeetCode.Problems._1603_Design_Parking_System;

[PublicAPI]
public interface ISolution
{
    public IParkingSystem Create(int big, int medium, int small);
}
