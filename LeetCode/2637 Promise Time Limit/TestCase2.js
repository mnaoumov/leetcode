module.exports = {
    fn: async (n) => {
        await new Promise(res => setTimeout(res, 100));
        return n * n;
    },
    inputs: [5],
    t: 150,
    output: { "resolved": 25, "time": 100 }
};
