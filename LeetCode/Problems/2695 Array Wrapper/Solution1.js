// https://leetcode.com/submissions/detail/961414584/

/**
 * @param {number[]} nums
 */
// ReSharper disable once InconsistentNaming
var ArrayWrapper = function(nums) {
    this.nums = nums;
};

ArrayWrapper.prototype.valueOf = function() {
    return this.nums.reduce((a, b) => a + b, 0);
}

ArrayWrapper.prototype.toString = function() {
    return `[${this.nums.join(",")}]`;
}

module.exports = ArrayWrapper;
