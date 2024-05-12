using JetBrains.Annotations;

namespace LeetCode.Problems._2402_Meeting_Rooms_III;

/// <summary>
/// https://leetcode.com/submissions/detail/908701574/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MostBooked(int n, int[][] meetings)
    {
        var counts = new int[n];

        var availableRoomsHeap = new PriorityQueue<int, int>();

        for (var i = 0; i < n; i++)
        {
            availableRoomsHeap.Enqueue(i, i);
        }

        var meetingStartHeep = new PriorityQueue<int, int>();

        for (var i = 0; i < meetings.Length; i++)
        {
            meetingStartHeep.Enqueue(i, meetings[i][0]);
        }

        var meetingEndHeep = new PriorityQueue<(int endingMeetingIndex, int room), int>();

        var result = 0;

        while (meetingStartHeep.Count > 0)
        {
            var startingMeetingIndex = meetingStartHeep.Peek();
            var startTime = meetings[startingMeetingIndex][0];
            var shouldStartMeeting = true;

            if (meetingEndHeep.Count > 0)
            {
                var (endingMeetingIndex, room) = meetingEndHeep.Peek();
                var endTime = meetings[endingMeetingIndex][1];

                if (endTime <= startTime || availableRoomsHeap.Count == 0)
                {
                    availableRoomsHeap.Enqueue(room, room);
                    shouldStartMeeting = false;
                    meetingEndHeep.Dequeue();

                    if (startTime < endTime)
                    {
                        meetings[startingMeetingIndex] = new[]
                            { endTime, meetings[startingMeetingIndex][1] + endTime - startTime };
                    }
                }
            }

            if (!shouldStartMeeting)
            {
                continue;
            }

            {
                meetingStartHeep.Dequeue();
                var room = availableRoomsHeap.Dequeue();
                counts[room]++;
                meetingEndHeep.Enqueue((startingMeetingIndex, room), meetings[startingMeetingIndex][1]);

                if (counts[room] > counts[result] || counts[room] == counts[result] && room < result)
                {
                    result = room;
                }
            }
        }

        return result;
    }
}
