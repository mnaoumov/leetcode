module.exports = {
    fn: async (n) => {
        await new Promise(res => setTimeout(res, 100));
        return n * n;
    },
    inputs: [5],
    t: 50,
    output: { "rejected": "Time Limit Exceeded", "time": 50 }
};
