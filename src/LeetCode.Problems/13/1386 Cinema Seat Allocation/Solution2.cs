namespace LeetCode.Problems._1386_Cinema_Seat_Allocation;

/// <summary>
/// https://leetcode.com/problems/cinema-seat-allocation/submissions/2112084725/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxNumberOfFamilies(int n, int[][] reservedSeats)
    {
        var ans = 2 * n;

        var seats2345 = new[] { 2, 3, 4, 5 };
        var seats4567 = new[] { 4, 5, 6, 7 };
        var seats6789 = new[] { 6, 7, 8, 9 };

        foreach (var group in reservedSeats.Select(arr => (row: arr[0], seat: arr[1])).GroupBy(x => x.row))
        {
            var availableSeats = Enumerable.Range(1, 10).Except(group.Select(x => x.seat)).ToHashSet();

            if (AreSeatsAvailable(availableSeats, seats2345, seats6789))
            {
                continue;
            }

            if (AreSeatsAvailable(availableSeats, seats2345) || AreSeatsAvailable(availableSeats, seats4567) || AreSeatsAvailable(availableSeats, seats6789))
            {
                ans--;
            }
            else
            {
                ans -= 2;
            }
        }

        return ans;
    }

    private static bool AreSeatsAvailable(HashSet<int> availableSeats, params int[][] seatGroups) =>
        seatGroups.SelectMany(seat => seat).All(availableSeats.Contains);
}
