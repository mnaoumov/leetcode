// https://leetcode.com/submissions/detail/948726324/

/**
 * @param {Function} fn
 * @return {Function}
 */
var once = function (fn) {
    let called = false;
    return function (...args) {
        if (called) {
            return undefined;
        }

        called = true;
        return fn(...args);
    }
};

module.exports = once;
