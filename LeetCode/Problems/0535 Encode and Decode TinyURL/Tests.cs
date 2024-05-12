using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0535_Encode_and_Decode_TinyURL;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var codec = solution.Create();
        Assert.That(codec.decode(codec.encode(testCase.Url)), Is.EqualTo(testCase.Url));
    }

    public class TestCase : TestCaseBase
    {
        public string Url { get; [UsedImplicitly] init; } = null!;
    }
}
