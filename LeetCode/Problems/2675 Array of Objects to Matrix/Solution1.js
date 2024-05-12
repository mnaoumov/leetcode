// https://leetcode.com/submissions/detail/955478841/

/**
 * @param {Array} arr
 * @return {Matrix}
 */
var jsonToMatrix = function(arr) {
    const keys = new Set();
    const maps = [];

    for (const item of arr) {
        const map = new Map();
        maps.push(map);
        flatten(map, null, item);

        // ReSharper disable once PossiblyUnassignedProperty
        for (const key of map.keys()) {
            keys.add(key);
        }
    }

    const keysArr = [...keys].sort();

    return [
        keysArr,
        // ReSharper disable once PossiblyUnassignedProperty
        ...maps.map(map => keysArr.map(key => map.has(key) ? map.get(key) : ""))
    ];
};

const flatten = (map, key, value) => {
    if (value === null || typeof value !== "object") {
        map.set(key, value);
        return;
    }

    for (const childKey of Object.keys(value)) {
        const childValue = value[childKey];
        const fullChildKey = key === null ? childKey : `${key}.${childKey}`;
        flatten(map, fullChildKey, childValue);
    }
};

module.exports = jsonToMatrix;
