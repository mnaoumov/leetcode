module.exports = {

    getInputs: () => [[{}, {}], [{}, {}], [{}, {}]],
    fn: (a, b) => ({ ...a, ...b }),
    output: [{ "val": {}, "calls": 1 }, { "val": {}, "calls": 2 }, { "val": {}, "calls": 3 }]
};
