using System.Globalization;

namespace LeetCode.Problems._2409_Count_Days_Spent_Together;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    private const int NonLeapYear = 2001;

    public int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob)
    {
        var arriveAliceDate = ToDate(arriveAlice);
        var leaveAliceDate = ToDate(leaveAlice);
        var arriveBobDate = ToDate(arriveBob);
        var leaveBobDate = ToDate(leaveBob);

        var maxArriveDate = Max(arriveAliceDate, arriveBobDate);
        var minLeaveDate = Min(leaveAliceDate, leaveBobDate);

        return Math.Max(0, (minLeaveDate - maxArriveDate).Days + 1);
    }

    private static DateTime ToDate(string str) => new DateTime(NonLeapYear, int.Parse(str[..2], CultureInfo.InvariantCulture), int.Parse(str[3..], CultureInfo.InvariantCulture));
    private static DateTime Max(DateTime x, DateTime y) => x >= y ? x : y;
    private static DateTime Min(DateTime x, DateTime y) => x <= y ? x : y;
}
