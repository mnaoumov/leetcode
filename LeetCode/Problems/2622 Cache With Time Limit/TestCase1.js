module.exports = {
    commands: ["TimeLimitedCache", "set", "get", "count", "get"],
    parameters: [[], [1, 42, 100], [1], [], [1]],
    times: [0, 0, 50, 50, 150],
    output: [null, false, 42, 1, -1]
};
