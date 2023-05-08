module.exports = async (solution, testCase) => {
    const compose = solution;
    return compose(testCase.functions)(testCase.x);
};
