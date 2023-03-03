using JetBrains.Annotations;

namespace LeetCode._1845_Seat_Reservation_Manager;

/// <summary>
/// https://leetcode.com/submissions/detail/908090691/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ISeatManager Create(int n)
    {
        return new SeatManager1(n);
    }
}
