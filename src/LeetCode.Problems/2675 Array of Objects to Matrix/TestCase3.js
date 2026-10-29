module.exports = {
    arr: [
        { "a": { "b": 1, "c": 2 } },
        { "a": { "b": 3, "d": 4 } }
    ],
    output: [
        ["a.b", "a.c", "a.d"],
        [1, 2, ""],
        [3, "", 4]
    ]
};
