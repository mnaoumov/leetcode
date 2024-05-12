using JetBrains.Annotations;

namespace LeetCode._1603_Design_Parking_System;

[PublicAPI]
public interface IParkingSystem
{
    public bool AddCar(int carType);
}
