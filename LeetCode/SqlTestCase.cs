namespace LeetCode;

public class SqlTestCase : TestCaseBase
{
    public Dictionary<string, string[]> Headers { get; set; } = null!;
    public Dictionary<string, object[][]> Rows { get; set; } = null!;
    public SqlTestCaseOutput Output { get; set; } = null!;

    public SqlTestCase()
    {
        TimeoutInMilliseconds = 30000;
    }
}