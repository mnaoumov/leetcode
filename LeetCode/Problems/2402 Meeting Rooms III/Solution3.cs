using JetBrains.Annotations;

namespace LeetCode.Problems._2402_Meeting_Rooms_III;

/// <summary>
/// https://leetcode.com/submissions/detail/911744672/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MostBooked(int n, int[][] meetings)
    {
        var longMeetings = meetings.Select(meeting => (startTime: (long) meeting[0], endTime: (long) meeting[1])).ToArray();

        var counts = new int[n];

        var availableRoomsHeap = new PriorityQueue<int, int>();

        for (var i = 0; i < n; i++)
        {
            availableRoomsHeap.Enqueue(i, i);
        }

        var meetingStartHeap = new PriorityQueue<int, (long startTime, int index)>();

        for (var i = 0; i < longMeetings.Length; i++)
        {
            meetingStartHeap.Enqueue(i, (longMeetings[i].startTime, i));
        }

        var meetingEndHeap = new PriorityQueue<(int endingMeetingIndex, int room), (long endTime, int room)>();

        var result = 0;

        while (meetingStartHeap.Count > 0)
        {
            var startingMeetingIndex = meetingStartHeap.Peek();
            var startTime = longMeetings[startingMeetingIndex].startTime;
            var shouldStartMeeting = true;

            if (meetingEndHeap.Count > 0)
            {
                var (endingMeetingIndex, room) = meetingEndHeap.Peek();
                var endTime = longMeetings[endingMeetingIndex].endTime;

                if (endTime <= startTime || availableRoomsHeap.Count == 0)
                {
                    availableRoomsHeap.Enqueue(room, room);
                    shouldStartMeeting = false;
                    meetingEndHeap.Dequeue();

                    if (startTime < endTime)
                    {
                        longMeetings[startingMeetingIndex] = (startTime: endTime,
                            endTime: longMeetings[startingMeetingIndex].endTime + endTime - startTime);
                        shouldStartMeeting = true;

                        if (longMeetings[startingMeetingIndex].endTime < 0)
                        {
                            throw new Exception(longMeetings[startingMeetingIndex].endTime.ToString());
                        }
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
                meetingEndHeap.Enqueue((startingMeetingIndex, room), (longMeetings[startingMeetingIndex].endTime, room));

                if (counts[room] > counts[result] || counts[room] == counts[result] && room < result)
                {
                    result = room;
                }
            }
        }

        return result;
    }
}
