namespace LeetCode._1603_Design_Parking_System;

/// <summary>
/// https://leetcode.com/submissions/detail/929812304/
/// </summary>
public class ParkingSystem1 : IParkingSystem
{
    private readonly Dictionary<int, int> _spotsAvailable;

    public ParkingSystem1(int big, int medium, int small)
    {
        _spotsAvailable = new Dictionary<int, int>
        {
            [1] = big,
            [2] = medium,
            [3] = small
        };
    }

    public bool AddCar(int carType)
    {
        if (_spotsAvailable[carType] == 0)
        {
            return false;
        }

        _spotsAvailable[carType]--;
        return true;
    }
}
