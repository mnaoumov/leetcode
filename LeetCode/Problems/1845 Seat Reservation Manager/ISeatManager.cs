namespace LeetCode.Problems._1845_Seat_Reservation_Manager;

[PublicAPI]
public interface ISeatManager
{
    int Reserve();
    void Unreserve(int seatNumber);
}
