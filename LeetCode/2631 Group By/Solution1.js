// https://leetcode.com/submissions/detail/946801425/

/**
 * @param {Function} fn
 * @return {Array}
 */
// ReSharper disable once NativeTypePrototypeExtending
Array.prototype.groupBy = function(fn) {
    debugger;
    const ans = {};

    for (let i = 0; i < this.length; i++) {
        const item = this[i];
        const group = fn(item);

        if (!ans.hasOwnProperty(group)) {
            ans[group] = [];
        }

        ans[group].push(item);
    }

    return ans;
};
