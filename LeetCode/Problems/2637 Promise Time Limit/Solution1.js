// https://leetcode.com/submissions/detail/951101775/

/**
 * @param {Function} fn
 * @param {number} t
 * @return {Function}
 */
var timeLimit = function(fn, t) {
    return async function(...args) {
        const fnPromise = (async () => fn(...args))();
        const timeoutPromise = new Promise((_, reject) => {
            setTimeout(() => { reject("Time Limit Exceeded"); }, t);
        });

        return await Promise.race([fnPromise, timeoutPromise]);
    }
};

module.exports = timeLimit;
