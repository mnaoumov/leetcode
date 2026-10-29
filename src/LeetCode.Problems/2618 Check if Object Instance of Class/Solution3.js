// https://leetcode.com/submissions/detail/932781150/

/**
 * @param {any} obj
 * @param {any} classFunction
 * @return {boolean}
 */
var checkIfInstanceOf = function (obj, classFunction) {
    if (classFunction === null || classFunction === undefined) {
        return false;
    }

    while (obj !== undefined && obj !== null) {
        obj = Object.getPrototypeOf(obj);
        if (obj === classFunction.prototype) {
            return true;
        }
    }

    return false;
};

module.exports = checkIfInstanceOf;
