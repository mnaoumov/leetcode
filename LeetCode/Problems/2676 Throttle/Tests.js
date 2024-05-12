module.exports = async (throttle, testCase) => {
    const output = [];
    const start = Date.now();
    const throttled = throttle((...args) => output.push({
            t: Date.now() - start,
            inputs: args
        }),
        testCase.t);

    const delay = (timeout) => new Promise(resolve => setTimeout(resolve, timeout));

    await Promise.all(testCase.calls.map(call => (async () => {
        await delay(call.t);
        throttled(...call.inputs);
    })()));

    return output;
};
