module.exports = {
    generatorFunction: function* () {
        yield new Promise(res => setTimeout(res, 200));
        return "Success";
    },
    cancelledAt: 100,
    output: { "rejected": "Cancelled" }
};
