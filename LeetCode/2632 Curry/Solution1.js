// https://leetcode.com/submissions/detail/946856604/

/**
 * @param {Function} fn
 * @return {Function}
 */
var curry = function(fn) {
    return function curried(...args) {
        if (args.length >= fn.length) {
            return fn(...args);
        }

        return (...args2) => curried(...[...args, ...args2]);
    };
};

module.exports = curry;
