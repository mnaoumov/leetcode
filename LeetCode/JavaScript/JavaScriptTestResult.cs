using JetBrains.Annotations;

namespace LeetCode.JavaScript
{
    public class JavaScriptTestResult
    {
        public string ActualResultJson { get; [UsedImplicitly] init; } = null!;
        public string ExpectedResultJson { get; [UsedImplicitly] init; } = null!;
    }
}
