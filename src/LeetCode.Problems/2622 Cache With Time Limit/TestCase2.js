module.exports = {
    commands: ["TimeLimitedCache", "set", "set", "get", "get", "get", "count"],
    parameters: [[], [1, 42, 50], [1, 50, 100], [1], [1], [1], []],
    times: [0, 0, 40, 50, 120, 200, 250],
    output: [null, false, true, 50, 50, -1, 0]
};
