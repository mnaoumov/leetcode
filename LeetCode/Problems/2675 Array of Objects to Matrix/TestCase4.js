module.exports = {
    arr: [
        [{ "a": null }],
        [{ "b": true }],
        [{ "c": "x" }]
    ],
    output: [
        ["0.a", "0.b", "0.c"],
        [null, "", ""],
        ["", true, ""],
        ["", "", "x"]
    ]
};
