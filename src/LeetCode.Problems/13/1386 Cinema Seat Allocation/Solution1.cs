namespace LeetCode.Problems._1386_Cinema_Seat_Allocation;

/// <summary>
/// https://leetcode.com/problems/cinema-seat-allocation/submissions/2112072101/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaxNumberOfFamilies(int n, int[][] reservedSeats)
    {
        var freeSeatsSets = Enumerable.Range(0, n + 1).Select(_ => Enumerable.Range(1, 10).ToHashSet()).ToArray();

        foreach (var pair in reservedSeats)
        {
            var row = pair[0];
            var seat = pair[1];

            freeSeatsSets[row].Remove(seat);
        }

        var seats2345 = new[] { 2, 3, 4, 5 };
        var seats4567 = new[] { 4, 5, 6, 7 };
        var seats6789 = new[] { 6, 7, 8, 9 };

        var ans = 0;

        for (var row = 1; row <= n; row++)
        {
            if (AreSeatsAvailable(row, seats2345, seats6789))
            {
                ans += 2;
            }
            else
            {
                if (AreSeatsAvailable(row, seats2345) || AreSeatsAvailable(row, seats4567) ||
                    AreSeatsAvailable(row, seats6789))
                {
                    ans++;
                }
            }
        }

        return ans;

        bool AreSeatsAvailable(int row, params int[][] seatGroups) =>
            seatGroups.SelectMany(seat => seat).All(seat => freeSeatsSets[row].Contains(seat));
    }
}
