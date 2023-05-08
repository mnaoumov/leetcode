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
    const solution = require(solutionFilePath);
    const testCase = require(testCaseFilePath);
    const test = require(testsFilePath);

    const actualResultPromise = Promise.resolve().then(() => test(solution, testCase));
    await clock.runAllAsync();

    let actualResult;

    try {
        actualResult = await actualResultPromise;
    } catch (e) {
        actualResult = e;
    }

    const actualResultJson = toJson(actualResult);
    const expectedResultJson = toJson(testCase.output);

    return {
        actualResultJson,
        expectedResultJson
    };
};
