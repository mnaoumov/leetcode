namespace LeetCode.Problems._3709_Design_Exam_Scores_Tracker;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-167/problems/design-exam-scores-tracker/submissions/1798410884/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IExamTracker Create() => new ExamTracker();

    private class ExamTracker : IExamTracker
    {
        private readonly List<Entry> _entries = new();

        public ExamTracker()
        {
            _entries.Add(new Entry(0, 0));
        }

        public void Record(int time, int score)
        {
            _entries.Add(new Entry(time, _entries[^1].PrefixScore + score));
        }

        public long TotalScore(int startTime, int endTime)
        {
            var startIndex = _entries.BinarySearch(new Entry(startTime, 0), Entry.ComparerByTime);
            var endIndex = _entries.BinarySearch(new Entry(endTime, 0), Entry.ComparerByTime);

            if (startIndex < 0)
            {
                startIndex = ~startIndex;
            }
            if (endIndex < 0)
            {
                endIndex = ~endIndex - 1;
            }

            return _entries[endIndex].PrefixScore - _entries[startIndex - 1].PrefixScore;
        }

        private record Entry(int Time, long PrefixScore)
        {
            public static readonly Comparer<Entry> ComparerByTime = Comparer<Entry>.Create((a, b) => a.Time.CompareTo(b.Time));
        }
    }
}
