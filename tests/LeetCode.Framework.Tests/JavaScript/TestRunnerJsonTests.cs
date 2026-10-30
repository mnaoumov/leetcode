using Jering.Javascript.NodeJS;

namespace LeetCode.Framework.Tests.JavaScript;

public class TestRunnerJsonTests
{
    private static readonly string TestRunnerScriptPath =
        Path.Combine(AppContext.BaseDirectory, "JavaScript", "TestRunner.js");

    // Each pair is two values the old encoding could not tell apart, or turned into the same JSON.
    private const string PairsModule = """
        module.exports = (callback, testRunnerScriptPath) => {
            const { toJson } = require(testRunnerScriptPath);
            const pairs = [
                [undefined, "<undefined>"],
                [[undefined], [null]],
                [{ a: undefined }, {}],
                [NaN, null],
                [Infinity, null],
                [-Infinity, Infinity],
                [10n, "10"],
                [new Map([[1, 2]]), {}],
                [new Map([[1, 2]]), new Map([[1, 3]])],
                [new Set([1]), new Set([2])],
                [new Set([1]), [1]],
                [{ $type: "undefined" }, undefined],
                [{ $type: "Set", values: [1] }, new Set([1])]
            ];
            callback(null, pairs.map(([a, b]) => [toJson(a), toJson(b)]));
        };
        """;

    private const string EqualPairsModule = """
        module.exports = (callback, testRunnerScriptPath) => {
            const { toJson } = require(testRunnerScriptPath);
            const pairs = [
                [{ b: 1, a: 2 }, { a: 2, b: 1 }],
                [new Map([[1, { y: 1, x: 2 }]]), new Map([[1, { x: 2, y: 1 }]])],
                [{ f: () => 1, a: 1 }, { a: 1 }]
            ];
            callback(null, pairs.map(([a, b]) => [toJson(a), toJson(b)]));
        };
        """;

    [Test]
    public async Task DistinctValues_GetDistinctJson()
    {
        var pairs = await InvokeAsync(PairsModule, "TestRunnerJsonTests.Distinct").ConfigureAwait(false);

        Assert.That(pairs, Has.Length.EqualTo(13));
        Assert.Multiple(() =>
        {
            foreach (var pair in pairs)
            {
                Assert.That(pair[0], Is.Not.EqualTo(pair[1]));
            }
        });
    }

    [Test]
    public async Task EqualValues_GetEqualJson()
    {
        var pairs = await InvokeAsync(EqualPairsModule, "TestRunnerJsonTests.Equal").ConfigureAwait(false);

        Assert.Multiple(() =>
        {
            foreach (var pair in pairs)
            {
                Assert.That(pair[0], Is.EqualTo(pair[1]));
            }
        });
    }

    private static async Task<string[][]> InvokeAsync(string module, string cacheIdentifier) =>
        (await StaticNodeJSService.InvokeFromStringAsync<string[][]>(module, cacheIdentifier,
            args: [TestRunnerScriptPath]).ConfigureAwait(false))!;
}
