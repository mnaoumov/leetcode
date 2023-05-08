module.exports = async (solution, testCase) => {
    const reduce = solution;
    return reduce(testCase.nums, testCase.fn, testCase.init);
};
