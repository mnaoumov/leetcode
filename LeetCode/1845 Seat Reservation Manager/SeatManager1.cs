namespace LeetCode._1845_Seat_Reservation_Manager;

/// <summary>
/// https://leetcode.com/submissions/detail/908090691/
/// </summary>
public class SeatManager1 : ISeatManager
{
    private readonly PriorityQueue<int, int> _heap = new();

    public SeatManager1(int n)
    {
        for (var i = 1; i <= n; i++)
        {
            _heap.Enqueue(i, i);
        }
    }

    public int Reserve() => _heap.Dequeue();

    public void Unreserve(int seatNumber) => _heap.Enqueue(seatNumber, seatNumber);
}
