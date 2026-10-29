// https://leetcode.com/submissions/detail/946329053/

/**
 * @param {Function} fn
 */
function memoize(fn) {
    const cache = new Map();

    return function(...args) {
        const key = JSON.stringify(args);
        if (cache.has(key)) {
            return cache.get(key);
        }

        const value = fn.apply(this, args);
        cache.set(key, value);
        return value;
    }
}

module.exports = memoize;
