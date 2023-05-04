namespace LeetCode;

public class JavaScriptTestCase : TestCaseBase
{
    public string InputFunctionStr { get; init; } = null!;
    public string OutputJson { get; init; } = null!;
    public Exception? Exception { get; init; }
}
