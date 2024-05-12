// https://leetcode.com/submissions/detail/953666417/

/**
 * @param {Function} fn
 * @param {number} t
 * @return {Function}
 */
var throttle = function (fn, t) {
    let nextArgs;
    let isDelayed = false;

    const throttledFn = (...args) => {
        if (!isDelayed) {
            setTimeout(() => {
                    isDelayed = false;

                    if (nextArgs !== undefined) {
                        const nextArgs2 = nextArgs;
                        nextArgs = undefined;
                        throttledFn(...nextArgs2);
                    }
                },
                t);
            isDelayed = true;
            fn(...args);
            return;
        }

        nextArgs = args;
    };

    return throttledFn;
};

module.exports = throttle;
