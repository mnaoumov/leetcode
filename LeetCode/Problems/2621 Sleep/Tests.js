module.exports = async (sleep, testCase) => {
    const t = Date.now();
    await sleep(testCase.millis);
    return Date.now() - t;
};
