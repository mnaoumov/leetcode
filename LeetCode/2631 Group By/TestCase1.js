module.exports = {
    array: [
        { "id": "1" },
        { "id": "1" },
        { "id": "2" }
    ],
    fn: function (item) {
        return item.id;
    },
    output:
    {
        "1": [{ "id": "1" }, { "id": "1" }],
        "2": [{ "id": "2" }]
    }
};
