// SkipSolution: WrongAnswer
// https://leetcode.com/submissions/detail/932780384/

/**
 * @param {any} obj
 * @param {any} classFunction
 * @return {boolean}
 */
var checkIfInstanceOf = function (obj, classFunction) {
    while (obj !== null) {
        obj = Object.getPrototypeOf(obj);
        if (obj === classFunction.prototype) {
            return true;
        }
    }

    return false;
};

module.exports = checkIfInstanceOf;
