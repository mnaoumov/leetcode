// https://leetcode.com/submissions/detail/946774306/

/**
 * @param {Function} fn
 */
function memoize(fn) {
    const cache = new Map();

    return function(...args) {
        let map = cache;

        for (const arg of args) {
            if (!map.has(arg)) {
                map.set(arg, new Map());
            }

            map = map.get(arg);
        }

        if (map.has("value")) {
            return map.get("value");
        }

        const value = fn(...args);
        map.set("value", value);
        return value;
    }
}

module.exports = memoize;
