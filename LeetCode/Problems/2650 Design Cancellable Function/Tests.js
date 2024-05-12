module.exports = async (cancellable, testCase) => {
    const [cancel, promise] = cancellable(testCase.generatorFunction());
    if (testCase.cancelledAt !== null) {
        setTimeout(cancel, testCase.cancelledAt);
    }

    try {
        const result = await promise;
        return {
            resolved: result
        };
    } catch (e) {
        return {
            rejected: e
        };
    }
};
