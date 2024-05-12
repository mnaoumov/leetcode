using JetBrains.Annotations;

namespace LeetCode._1845_Seat_Reservation_Manager;

[PublicAPI]
public interface ISeatManager
{
    public int Reserve();
    public void Unreserve(int seatNumber);
}
