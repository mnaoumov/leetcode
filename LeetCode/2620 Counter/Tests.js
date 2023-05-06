module.exports = async (solution, testCase) => {
    const createCounter = solution;
    const counter = createCounter(testCase.n);
    return Array.from(Array(testCase.m)).map(_ => counter());
};
