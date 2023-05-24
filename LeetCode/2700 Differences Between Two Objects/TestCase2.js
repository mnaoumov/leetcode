module.exports = {
    obj1: {
        "a": 1,
        "v": 3,
        "x": [],
        "z": {
            "a": null
        }
    },
    obj2: {
        "a": 2,
        "v": 4,
        "x": [],
        "z": {
            "a": 2
        }
    },
    output: {
        "a": [1, 2],
        "v": [3, 4],
        "z": {
            "a": [null, 2]
        }
    }
};
