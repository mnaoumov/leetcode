module.exports = {
    generatorFunction: function* () {
        const msg = yield new Promise(res => res("Hello"));
        throw `Error: ${msg}`;
    },
    cancelledAt: null,
    output: { "rejected": "Error: Hello" }
};
