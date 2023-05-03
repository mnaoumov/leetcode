// https://leetcode.com/submissions/detail/943601776/

/**
 * @param {number} n
 * @return {Function} counter
 */
var createCounter = function(n) {
    let value = n;

    return function() {
        const previousValue = value;
        value++;
        return previousValue;
    };
};
