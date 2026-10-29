namespace LeetCode.Problems._3433_Count_Mentions_Per_User;

/// <summary>
/// https://leetcode.com/problems/count-mentions-per-user/submissions/1853399883/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] CountMentions(int numberOfUsers, IList<IList<string>> events)
    {
        var eventObjs = events
            .SelectMany(data =>
            {
                var @event = Event.Create(data);

                if (@event is OfflineEvent offlineEvent)
                {
                    return new Event[] { offlineEvent, new OnlineEvent(offlineEvent.Timestamp + 60, offlineEvent.UserId) };
                }
                return new[] { @event };
            })
            .OrderBy(e => e.Timestamp)
            .ThenBy(e => e.Type)
            .ToArray();


        var users = Enumerable.Range(0, numberOfUsers).Select(_ => new User()).ToArray();

        foreach (var @event in eventObjs)
        {
            @event.Process(users);
        }

        return users.Select(user => user.MentionsCount).ToArray();
    }

    private class User
    {
        public int MentionsCount { get; set; }
        public bool IsOnline { get; set; } = true;
    }

    private abstract record Event(int Timestamp, EventType Type)
    {
        public static Event Create(IList<string> data)
        {
            var eventType = data[0];
            var timestamp = int.Parse(data[1]);

            switch (eventType)
            {
                case "MESSAGE":
                    var mentionsStr = data[2];
                    var mentionsStrs = mentionsStr.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var mentions = mentionsStrs.Select(Mention.Parse).ToArray();
                    return new MessageEvent(timestamp, mentions);
                case "OFFLINE":
                    var userId = int.Parse(data[2]);
                    return new OfflineEvent(timestamp, userId);
                default:
                    throw new ArgumentOutOfRangeException(nameof(data), $"Unknown event type: {eventType}");
            }
        }

        public abstract void Process(User[] users);
    }

    private record MessageEvent(int Timestamp, Mention[] Mentions) : Event(Timestamp, EventType.Message)
    {
        public override void Process(User[] users)
        {
            foreach (var mention in Mentions)
            {
                mention.Process(users);
            }
        }
    }

    private enum EventType
    {
        Online,
        Offline,
        Message
    }

    private abstract record Mention
    {
        public static Mention Parse(string str)
        {
            switch (str)
            {
                case "ALL":
                    return new MentionAllUsers();
                case "HERE":
                    return new MentionOnlineUsers();
            }

            if (!str.StartsWith("id"))
            {
                throw new ArgumentOutOfRangeException(nameof(str), $"Unknown mention type: {str}");
            }

            var id = int.Parse(str[2..]);
            return new MentionUser(id);
        }

        public abstract void Process(User[] users);
    }

    private record OfflineEvent(int Timestamp, int UserId) : Event(Timestamp, EventType.Offline)
    {
        public override void Process(User[] users)
        {
            users[UserId].IsOnline = false;
        }
    }

    private record OnlineEvent(int Timestamp, int UserId) : Event(Timestamp, EventType.Online)
    {
        public override void Process(User[] users)
        {
            users[UserId].IsOnline = true;
        }
    }

    private record MentionUser(int Id) : Mention
    {
        public override void Process(User[] users)
        {
            users[Id].MentionsCount++;
        }
    }

    private record MentionAllUsers : Mention
    {
        public override void Process(User[] users)
        {
            foreach (var user in users)
            {
                user.MentionsCount++;
            }
        }
    }

    private record MentionOnlineUsers : Mention
    {
        public override void Process(User[] users)
        {
            foreach (var user in users)
            {
                if (user.IsOnline)
                {
                    user.MentionsCount++;
                }
            }
        }
    }
}
