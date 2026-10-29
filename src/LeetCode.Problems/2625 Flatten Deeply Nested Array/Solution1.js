// https://leetcode.com/submissions/detail/946363407/

/**
 * @param {any[]} arr
 * @param {number} depth
 * @return {any[]}
 */
var flat = function (arr, n) {
    if (n === 0) {
        return arr;
    }

    const ans = [];

    for (let item of arr) {
        if (Array.isArray(item)) {
            for (const item2 of flat(item, n - 1)) {
                ans.push(item2);
            }
        } else {
            ans.push(item);
        }
    }

    return ans;
};

module.exports = flat;
