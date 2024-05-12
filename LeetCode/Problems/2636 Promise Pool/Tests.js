module.exports = async (promisePool, testCase) => {
    const times = [];
    let lastTime;
    const start = Date.now();

    await promisePool(testCase.functions.map((fn, i) => async () => {
            await fn();
            const time = Date.now() - start;
            times[i] = time;
            lastTime = time;
        }),
        testCase.n);
    return [times, lastTime];
};
