module.exports = async (timeLimit, testCase) => {
    const start = Date.now();
    try {
        const ans = await timeLimit(testCase.fn, testCase.t)(...testCase.inputs);
        return {
            resolved: ans,
            time: Date.now() - start
        };
    } catch (e) {
        return {
            // ReSharper disable once PossiblyUnassignedProperty
            rejected: e,
            time: Date.now() - start
        }
    }
};
