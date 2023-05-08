// https://leetcode.com/submissions/detail/946864803/

/**
 * @param {any} object
 * @return {string}
 */
var jsonStringify = function(object) {
    debugger;
    if (object === null) {
        return "null";
    }

    if (object === undefined) {
        return "undefined";
    }

    const type = typeof object;

    if (["number", "boolean"].includes(type)) {
        return object.toString();
    }

    if (type === "string") {
        return `"${object}"`;
    }

    if (Array.isArray(object)) {
        return `[${object.map(item => jsonStringify(item)).join(",")}]`;
    }

    return `{${Object.keys(object).map(key => `"${key}":${jsonStringify(object[key])}`).join(",")}}`;
};

module.exports = jsonStringify;
