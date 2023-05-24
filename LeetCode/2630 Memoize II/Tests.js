module.exports = async (memoize, testCase) => {
    const inputs = testCase.getInputs();
    let callCount = 0;
    const memoized = memoize((...args) => {
        callCount++;
        return testCase.fn(...args);
    });

    return inputs.map(arr => ({
        val: memoized(...arr),
        calls: callCount
    }));
};
