using JetBrains.Annotations;

namespace LeetCode._2402_Meeting_Rooms_III;

/// <summary>
/// https://leetcode.com/submissions/detail/911739491/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MostBooked(int n, int[][] meetings)
    {
        var counts = new int[n];

        var availableRoomsHeap = new PriorityQueue<int, int>();

        for (var i = 0; i < n; i++)
        {
            availableRoomsHeap.Enqueue(i, i);
        }

        var meetingStartHeap = new PriorityQueue<int, (int startTime, int index)>();

        for (var i = 0; i < meetings.Length; i++)
        {
            meetingStartHeap.Enqueue(i, (meetings[i][0], i));
        }

        var meetingEndHeap = new PriorityQueue<(int endingMeetingIndex, int room), (int endTime, int room)>();

        var result = 0;

        while (meetingStartHeap.Count > 0)
        {
            var startingMeetingIndex = meetingStartHeap.Peek();
            var startTime = meetings[startingMeetingIndex][0];
            var shouldStartMeeting = true;

            if (meetingEndHeap.Count > 0)
            {
                var (endingMeetingIndex, room) = meetingEndHeap.Peek();
                var endTime = meetings[endingMeetingIndex][1];

                if (endTime <= startTime || availableRoomsHeap.Count == 0)
                {
                    availableRoomsHeap.Enqueue(room, room);
                    shouldStartMeeting = false;
                    meetingEndHeap.Dequeue();

                    if (startTime < endTime)
                    {
                        meetings[startingMeetingIndex] = new[]
                            { endTime, meetings[startingMeetingIndex][1] + endTime - startTime };
                        shouldStartMeeting = true;
                    }
                }
            }

            if (!shouldStartMeeting)
            {
                continue;
            }

            {
                meetingStartHeap.Dequeue();
                var room = availableRoomsHeap.Dequeue();
                counts[room]++;
                meetingEndHeap.Enqueue((startingMeetingIndex, room), (meetings[startingMeetingIndex][1], room));

                if (counts[room] > counts[result] || counts[room] == counts[result] && room < result)
                {
                    result = room;
                }
            }
        }

        return result;
    }
}
