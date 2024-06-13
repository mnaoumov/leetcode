using JetBrains.Annotations;

namespace LeetCode.Problems._2037_Minimum_Number_of_Moves_to_Seat_Everyone;

/// <summary>
/// https://leetcode.com/submissions/detail/1286488481/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinMovesToSeat(int[] seats, int[] students)
    {
        Array.Sort(seats);
        Array.Sort(students);
        return seats.Zip(students, (seat, student) => (seat, student)).Select(x => Math.Abs(x.seat - x.student)).Sum();
    }
}
