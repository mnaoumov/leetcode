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
    let actualResult;
    let output = null;

    try {
        const testCase = require(testCaseFilePath);
        output = testCase.output;

        const solution = require(solutionFilePath);
        const test = require(testsFilePath);

        let error = null;
// ReSharper disable once AssignedValueIsNeverUsed
        const actualResultPromise = Promise.resolve().then(() => test(solution, testCase)).catch((e2) => error = e2);
// ReSharper disable once AssignedValueIsNeverUsed
        await clock.runAllAsync().catch((e2) => error = e2);
        actualResult = await actualResultPromise;
        if (error !== null) {
            actualResult = error;
        }
    } catch (e) {
        actualResult = e;
    }

    const actualResultJson = toJson(actualResult);
    const expectedResultJson = toJson(output);

    return {
        actualResultJson,
        expectedResultJson
    };
};
