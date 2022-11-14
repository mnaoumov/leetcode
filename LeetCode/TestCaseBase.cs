using System.ComponentModel;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace LeetCode;

public abstract class TestCaseBase
{
    [JsonIgnore]
    public string? TestCaseName { get; set; }
    
    [JsonIgnore]
    public Exception? JsonParsingException { get; init; }

    [DefaultValue(200)]
    public int TimeoutInMilliseconds { get; [UsedImplicitly] init; } = 200;
}