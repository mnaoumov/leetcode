module.exports = async (solution, testCase) => {
    const debounce = solution;
    const ans = [];
    const start = Date.now();
    function log(...inputs) {
        const t = Date.now() - start;
        ans.push({
            t,
            inputs
        });
    }

    const debouncedLog = debounce(log, testCase.t);

    const delay = (timeout) => new Promise(resolve => setTimeout(resolve, timeout));

    const promises = testCase.calls.map(async (call) => {
        await delay(call.t);
        debouncedLog(...call.inputs);
    });

    await Promise.all(promises);
    return ans;
};
