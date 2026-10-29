// https://leetcode.com/submissions/detail/946864803/

/**
 * @param {any} object
 * @return {string}
 */
var jsonStringify = function(object) {
    if (object === null) {
        return "null";
    }

    if (object === undefined) {
        return "undefined";
    }

    const type = typeof object;

        // ReSharper disable once PossiblyUnassignedProperty
    if (["number", "boolean"].includes(type)) {
        return object.toString();
    }

    if (type === "string") {
        return `"${object}"`;
    }

    if (Array.isArray(object)) {
        // ReSharper disable once PossiblyUnassignedProperty
        return `[${object.map(item => jsonStringify(item)).join(",")}]`;
    }

    return `{${Object.keys(object).map(key => `"${key}":${jsonStringify(object[key])}`).join(",")}}`;
};

module.exports = jsonStringify;
