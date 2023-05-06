const FakeTimers = require("@sinonjs/fake-timers");
FakeTimers.install({
    shouldAdvanceTime: true
});

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

    let actualResult;
    
    try {
        actualResult = await test(solution, testCase);
    } catch (e) {
        actualResult = e;
    }

    const actualResultJson = toJson(actualResult);
    const expectedResultJson = toJson(testCase.output);

    if (actualResultJson !== expectedResultJson) {
        throw `Actual: ${actualResultJson}\nExpected: ${expectedResultJson}`;
    }
};
