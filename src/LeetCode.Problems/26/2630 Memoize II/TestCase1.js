module.exports = {
    getInputs: () => [[2, 2], [2, 2], [1, 2]],
    fn: (a, b) => a + b,
    output: [{ "val": 4, "calls": 1 }, { "val": 4, "calls": 1 }, { "val": 3, "calls": 2 }]
};
