namespace LeetCode.Problems._0359_Logger_Rate_Limiter;

[PublicAPI]
public interface ILogger
{
    public bool ShouldPrintMessage(int timestamp, string message);
}
