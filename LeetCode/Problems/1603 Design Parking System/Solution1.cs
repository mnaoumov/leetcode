using JetBrains.Annotations;

namespace LeetCode._1603_Design_Parking_System;

/// <summary>
/// https://leetcode.com/submissions/detail/929812304/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IParkingSystem Create(int big, int medium, int small) => new ParkingSystem(big, medium, small);

    private class ParkingSystem : IParkingSystem
    {
        private readonly Dictionary<int, int> _spotsAvailable;

        public ParkingSystem(int big, int medium, int small)
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
}
