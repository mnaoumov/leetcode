using JetBrains.Annotations;

namespace LeetCode._2402_Meeting_Rooms_III;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MostBooked(int n, int[][] meetings)
    {
        var counts = new int[n];

        var availableRoomsHeap = new PriorityQueue<int, int>();

        for (var i = 0; i < n; i++)
        {
            availableRoomsHeap.Enqueue(i, i);
        }

        var timeHeap = new PriorityQueue<(int meetingIndex, int roomNumber), (int time, int roomNumber, int meetingIndex)>();
        const int noRoom = -1;

        for (var i = 0; i < meetings.Length; i++)
        {
            var meeting = meetings[i];
            timeHeap.Enqueue((i, noRoom), (meeting[0], noRoom, i));
        }

        var result = 0;
        var skippedMeetingsHeap = new PriorityQueue<int, int>();

        while (timeHeap.Count > 0)
        {
            var (meetingIndex, room) = timeHeap.Dequeue();
            var endTime = meetings[meetingIndex][1];

            if (room != noRoom)
            {
                if (skippedMeetingsHeap.Count <= 0)
                {
                    availableRoomsHeap.Enqueue(room, room);
                    continue;
                }

                var skippedMeetingIndex = skippedMeetingsHeap.Dequeue();
                var skippedMeeting = meetings[skippedMeetingIndex];
                var duration = skippedMeeting[1] - skippedMeeting[0];
                var newEndTime = endTime + duration;
                timeHeap.Enqueue((skippedMeetingIndex, room), (newEndTime, room, skippedMeetingIndex));
                skippedMeeting[0] = endTime;
                skippedMeeting[1] = newEndTime;
                counts[room]++;
                if (counts[room] > counts[result] || counts[room] == counts[result] && room < result)
                {
                    result = room;
                }
            }
            else if (availableRoomsHeap.Count > 0)
            {
                room = availableRoomsHeap.Dequeue();
                timeHeap.Enqueue((meetingIndex, room), (endTime, room, meetingIndex));
                counts[room]++;
                if (counts[room] > counts[result] || counts[room] == counts[result] && room < result)
                {
                    result = room;
                }
            }
            else
            {
                skippedMeetingsHeap.Enqueue(meetingIndex, meetingIndex);
            }
        }

        return result;
    }
}
