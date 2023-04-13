// https://leetcode.com/submissions/detail/932781150/

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
