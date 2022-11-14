using JetBrains.Annotations;
using Newtonsoft.Json;

namespace LeetCode;

public abstract class TestCaseBase<TTestCase> where TTestCase : TestCaseBase<TTestCase>
{
    [JsonIgnore]
    public string? TestCaseName { get; set; }
    
    [JsonIgnore]
    public Exception? JsonParsingException { get; init; }

    public int TimeoutInMilliseconds { get; [UsedImplicitly] init; } = 200;

    public virtual IEnumerable<TTestCase> TestCases
    {
        get { throw new NotImplementedException(); }
    }
}