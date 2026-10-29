module.exports = {
    getInputs: () => { const o = {}; return [[o, o], [o, o], [o, o]]; },
    fn: (a, b) => ({ ...a, ...b }),
    output: [{ "val": {}, "calls": 1 }, { "val": {}, "calls": 1 }, { "val": {}, "calls": 1 }]
};
