module.exports = {
    generatorFunction: function* () {
        let result = 0;
        yield new Promise(res => setTimeout(res, 100));
        result += yield new Promise(res => res(1));
        yield new Promise(res => setTimeout(res, 100));
        result += yield new Promise(res => res(1));
        return result;
    },
    cancelledAt: null,
    output: { "resolved": 2 }
};
