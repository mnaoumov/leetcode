using LeetCode.Base;
using LeetCode.Helpers;

namespace LeetCode.Framework.Tests.Base;

public class LoadTestCaseTests : TestsBase
{
    public sealed class ValueTestCase : TestCaseBase
    {
        public int Value { get; init; }
    }

    [Test]
    public void ReadsTheFileAndNamesTheCaseAfterIt()
    {
        var testCase = Load("""{ "value": 7, "timeoutInMilliseconds": 900 }""");

        Assert.Multiple(() =>
        {
            Assert.That(testCase.JsonParsingException, Is.Null);
            Assert.That(testCase.Value, Is.EqualTo(7));
            Assert.That(testCase.TimeoutInMilliseconds, Is.EqualTo(900));
            Assert.That(testCase.TestCaseName, Is.EqualTo("TestCase3"));
        });
    }

    // The base class's properties have defaults, so a test case need not repeat them.
    [Test]
    public void BasePropertiesAreOptional()
    {
        var testCase = Load("""{ "value": 7 }""");

        Assert.Multiple(() =>
        {
            Assert.That(testCase.JsonParsingException, Is.Null);
            Assert.That(testCase.TimeoutInMilliseconds, Is.EqualTo(200));
        });
    }

    [TestCase("""{ }""", TestName = "A missing property")]
    [TestCase("""{ "value": 7, "valeu": 8 }""", TestName = "An unknown property")]
    [TestCase("""{ "value": """, TestName = "Malformed JSON")]
    [TestCase("""null""", TestName = "A null test case")]
    public void ABadFileIsReturnedCarryingItsException(string json)
    {
        var testCase = Load(json);

        Assert.Multiple(() =>
        {
            Assert.That(testCase.JsonParsingException, Is.Not.Null);
            Assert.That(testCase.TestCaseName, Is.EqualTo("TestCase3"));
        });
    }

    // A bad file fails its own test, not the discovery of every test of the problem.
    [Test]
    public void ABadFileFailsItsTestWithoutRunningIt()
    {
        var testCase = Load("""{ "value": 7, "valeu": 8 }""");
        var ran = false;

        var exception = Assert.Throws<AssertionException>(() => RunTestWithTimeout(testCase, () => ran = true));

        Assert.Multiple(() =>
        {
            Assert.That(ran, Is.False);
            Assert.That(exception.Message, Does.Contain("valeu"));
        });
    }

    private static ValueTestCase Load(string json)
    {
        using var tempDir = new TempDir();
        var path = Path.Combine(tempDir.Path, "TestCase3.json");
        File.WriteAllText(path, json);
        return LoadTestCase<ValueTestCase>(path);
    }
}
