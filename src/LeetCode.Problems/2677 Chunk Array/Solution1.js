// https://leetcode.com/submissions/detail/956805990/

/**
 * @param {Array} arr
 * @param {number} size
 * @return {Array[]}
 */
var chunk = function(arr, size) {
    const ans = [];

    for (let i = 0; i < arr.length; i++) {
        if (i % size === 0) {
            ans.push([]);
        }

        ans[ans.length - 1].push(arr[i]);
    }

    return ans;
};


module.exports = chunk;
