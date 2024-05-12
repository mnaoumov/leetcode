using JetBrains.Annotations;

namespace LeetCode.Problems._2402_Meeting_Rooms_III;

/// <summary>
/// https://leetcode.com/submissions/detail/911800442/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution4 : ISolution
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

        var timeHeap = new PriorityQueue<(int meetingIndex, int roomNumber), (long time, int roomNumber, int meetingIndex)>();
        const int noRoom = -1;

        for (var i = 0; i < longMeetings.Length; i++)
        {
            var (startTime, _) = longMeetings[i];
            timeHeap.Enqueue((i, noRoom), (startTime, noRoom, i));
        }

        var result = 0;
        var skippedMeetingsHeap = new PriorityQueue<int, long>();

        while (timeHeap.Count > 0)
        {
            var (meetingIndex, room) = timeHeap.Dequeue();
            var endTime = longMeetings[meetingIndex].endTime;

            if (room != noRoom)
            {
                if (skippedMeetingsHeap.Count == 0)
                {
                    availableRoomsHeap.Enqueue(room, room);
                    continue;
                }

                var skippedMeetingIndex = skippedMeetingsHeap.Dequeue();
                var skippedMeeting = longMeetings[skippedMeetingIndex];
                var duration = skippedMeeting.endTime - skippedMeeting.startTime;
                var newEndTime = endTime + duration;
                timeHeap.Enqueue((skippedMeetingIndex, room), (newEndTime, room, skippedMeetingIndex));
                longMeetings[skippedMeetingIndex] = (startTime: endTime, endTime: newEndTime);
                AddCount(room);
            }
            else if (availableRoomsHeap.Count > 0)
            {
                room = availableRoomsHeap.Dequeue();
                timeHeap.Enqueue((meetingIndex, room), (endTime, room, meetingIndex));
                AddCount(room);
            }
            else
            {
                skippedMeetingsHeap.Enqueue(meetingIndex, meetings[meetingIndex][0]);
            }
        }

        return result;

        void AddCount(int room)
        {
            counts[room]++;

            if (counts[room] > counts[result] || counts[room] == counts[result] && room < result)
            {
                result = room;
            }
        }
    }
}
