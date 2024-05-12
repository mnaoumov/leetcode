module.exports = async (once, testCase) => {
    let callsCount = 0;
    let lastValue;
    const wrapFn = (...args) => {
        callsCount++;
        lastValue = testCase.fn(...args);
        return lastValue;
    };
    const onceFn = once(wrapFn);
    for (const call of testCase.calls) {
        onceFn(...call);
    }

    return [{
        calls: callsCount,
        value: lastValue
    }];
};
