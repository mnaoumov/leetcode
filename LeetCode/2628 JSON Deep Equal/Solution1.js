// TODO url

/**
 * @param {any} o1
 * @param {any} o2
 * @return {boolean}
 */
var areDeeplyEqual = function(o1, o2) {
    if (o1 === o2) {
        return true;
    }

    if (o1 == null || o2 == null) {
        return false;
    }

    const isArray1 = Array.isArray(o1);
    const isArray2 = Array.isArray(o2);

    if (isArray1 || isArray2) {
        return isArray1 &&
            isArray2 &&
            o1.length === o2.length &&
            Array.from(o1.keys()).every(i => areDeeplyEqual(o1[i], o2[i]));
    }

    const isObject1 = typeof o1 === "object";
    const isObject2 = typeof o2 === "object";

    if (isObject1 || isObject2) {
        if (isObject1 && isObject2) {
            const keys1 = Object.keys(o1).sort();
            const keys2 = Object.keys(o2).sort();

            return areDeeplyEqual(keys1, keys2) && keys1.every(key => areDeeplyEqual(o1[key], o2[key]));
        }

        return false;
    }

    return false;
};

module.exports = areDeeplyEqual;
