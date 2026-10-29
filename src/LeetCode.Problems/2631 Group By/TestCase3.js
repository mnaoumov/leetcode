module.exports = {
    array: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10],
    fn: function (n) {
        return String(n > 5);
    },
    output:
    {
        "true": [6, 7, 8, 9, 10],
        "false": [1, 2, 3, 4, 5]
    }
};
