const fakeTimers = require("@sinonjs/fake-timers");
const clock = fakeTimers.install();

const jsonFriendlyErrorReplacer = (_, value) => {
    if (value instanceof Error) {
        return {
            ...value,
            name: value.name,
            message: value.message,
            stack: value.stack
        };
    }

    return value;
}

const toJson = (obj) => JSON.stringify(obj, jsonFriendlyErrorReplacer);

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
