namespace LeetCode.Problems._0359_Logger_Rate_Limiter;

/// <summary>
/// https://leetcode.com/problems/logger-rate-limiter/submissions/1629685298/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ILogger Create() => new Logger();

    private class Logger : ILogger
    {
        private readonly Dictionary<string, int> _messageNextTimestamps = new();

        public bool ShouldPrintMessage(int timestamp, string message)
        {
            if (_messageNextTimestamps.TryGetValue(message, out var nextTimestamp) && timestamp < nextTimestamp)
            {
                return false;
            }

            _messageNextTimestamps[message] = timestamp + 10;
            return true;
        }
    }
}
