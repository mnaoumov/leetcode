module.exports = async (solution, testCase) => {
    const sleep = solution;
    const t = Date.now();
    await sleep(testCase.millis);
    return Date.now() - t;
};
