module.exports = {
    generatorFunction: function* () {
        try {
            yield new Promise((resolve, reject) => reject("Promise Rejected"));
            return undefined;
        } catch (e) {
            const a = yield new Promise(resolve => resolve(2));
            const b = yield new Promise(resolve => resolve(2));
            return a + b;
        }
    },
    cancelledAt: null,
    output: { "resolved": 4 }
};
