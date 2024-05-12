// https://leetcode.com/submissions/detail/956146711/

/**
 * @param {object} obj1
 * @param {object} obj2
 * @return {object}
 */
function objDiff(obj1, obj2) {
    const ans = {};
    for (const key of Object.keys(obj1)) {
        if (!obj2.hasOwnProperty(key)) {
            continue;
        }
        const value1 = obj1[key];
        const value2 = obj2[key];

        if (value1 === value2) {
            continue;
        }

        const type1 = getType(value1);
        const type2 = getType(value2);

        if (type1 === type2 && (type1 === "array" || type1 === "object")) {
            const valueDiff = objDiff(value1, value2);
            if (Object.keys(valueDiff).length === 0) {
                continue;
            }

            ans[key] = valueDiff;
            continue;
        }

        ans[key] = [value1, value2];
    }

    return ans;
};

const getType = (obj) => {
    if (obj === null) {
        return "null";
    }

    if (Array.isArray(obj)) {
        return "array";
    }

    return typeof obj;
}

module.exports = objDiff;
