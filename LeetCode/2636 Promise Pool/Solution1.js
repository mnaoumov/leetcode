// https://leetcode.com/submissions/detail/951072639/

/**
 * @param {Function[]} functions
 * @param {number} n
 * @return {Function}
 */
var promisePool = async function(functions, n) {
    const pool = new Set();

    let i;

    for (i = 0; i < Math.min(n, functions.length); i++) {
        pool.add(functions[i]);
    }

    const promisesMap = new Map();

    while (pool.size > 0) {
        const promises = Array.from(pool).map(fn => {
            if (promisesMap.has(fn)) {
                return promisesMap.get(fn);
            }

            const promise = (async () => {
                await fn();
                pool.delete(fn);
            })();

            promisesMap.set(fn, promise);
            return promise;
        });

        await Promise.any(promises);

        if (i < functions.length) {
            pool.add(functions[i]);
            i++;
        }
    }
};

module.exports = promisePool;
