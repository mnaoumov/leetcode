// SkipSolution: TimeLimitExceeded
// https://leetcode.com/submissions/detail/946755345/

/**
 * @param {Function} fn
 */
function memoize(fn) {
    const cache = new Map();

    return function(...args) {
        for (const cachedFuncArgs of cache.keys()) {
            if (cachedFuncArgs.length !== args.length) {
                continue;
            }
            // ReSharper disable once PossiblyUnassignedProperty
            if (Array.from(cachedFuncArgs.keys()).every(i => cachedFuncArgs[i] === args[i])) {
                return cache.get(cachedFuncArgs);
            }
        }

        const value = fn(...args);
        cache.set(args, value);
        return value;
    }
}

module.exports = memoize;
