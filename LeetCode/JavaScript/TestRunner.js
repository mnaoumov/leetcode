const fakeTimers = require("@sinonjs/fake-timers");
const clock = fakeTimers.install();

const toJson = (obj) => JSON.stringify(obj, (_, value) => {
    if (value === undefined) {
        return "<undefined>";
    }

    if (value === null) {
        return null;
    }

    if (value instanceof Error) {
        value = {
            ...value,
            name: value.name,
            message: value.message,
            stack: value.stack
        };
    }

    if (typeof value === "object" && !Array.isArray(value)) {
        const sortedKeys = Object.keys(value).sort();
        const value2 = {};
        for (const key of sortedKeys) {
            value2[key] = value[key];
        }

        value = value2;
    }

    return value;
});

module.exports = async (solutionFilePath, testCaseFilePath, testsFilePath) => {
    let actualResult = null;
    let output = null;
    const errors = [];

    try {

        // ReSharper disable once UseOfImplicitGlobalInFunctionScope
        process.on("unhandledRejection", e2 => errors.push(e2));

        const testCase = require(testCaseFilePath);
        // ReSharper disable once PossiblyUnassignedProperty
        output = testCase.output;

        const solution = require(solutionFilePath);
        const test = require(testsFilePath);

        const actualResultPromise = (async () => await test(solution, testCase))();
        await clock.runAllAsync();
        actualResult = await actualResultPromise;
    } catch (e) {
        errors.push(e);
    }

    if (errors.length > 0) {
        actualResult = errors;
    }

    const actualResultJson = toJson(actualResult);
    const expectedResultJson = toJson(output);

    return {
        actualResultJson,
        expectedResultJson
    };
};
