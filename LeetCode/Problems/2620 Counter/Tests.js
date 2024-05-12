module.exports = async (createCounter, testCase) => {
    const counter = createCounter(testCase.n);
    return Array.from(Array(testCase.m)).map(() => counter());
};
