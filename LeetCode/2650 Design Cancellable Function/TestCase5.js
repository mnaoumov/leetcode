module.exports = {
    generatorFunction: function* () {
        let result = 0;
        try {
            yield new Promise(res => setTimeout(res, 100));
            result += yield new Promise(res => res(1));
            yield new Promise(res => setTimeout(res, 100));
            result += yield new Promise(res => res(1));
        } catch (e) {
            return result;
        }
        return result;
    },
    cancelledAt: 150,
    output: { "resolved": 1 }
};
