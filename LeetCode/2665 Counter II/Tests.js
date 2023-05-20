module.exports = async (solution, testCase) => {
    const createCounter = solution;
    const counter = createCounter(testCase.init);

    const ans = [];

    for (const call of testCase.calls) {
        ans.push(counter[call]());
    }

    return ans;
};
