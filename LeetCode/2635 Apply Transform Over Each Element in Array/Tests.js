module.exports = async (solution, testCase) => {
    const map = solution;
    return map(testCase.arr, testCase.fn);
};
