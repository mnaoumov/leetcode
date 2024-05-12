module.exports = {
    fn: async (a, b) => {
        await new Promise(res => setTimeout(res, 120));
        return a + b;
    },
    inputs: [5, 10],
    t: 150,
    output: { "resolved": 15, "time": 120 }
};
