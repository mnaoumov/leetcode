module.exports = {
    array: [
        [1, 2, 3],
        [1, 3, 5],
        [1, 5, 9]
    ],
    fn: function (list) {
        return String(list[0]);
    },
    output:
    {
        "1": [[1, 2, 3], [1, 3, 5], [1, 5, 9]]
    }
};
