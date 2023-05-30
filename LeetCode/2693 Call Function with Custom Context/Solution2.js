// https://leetcode.com/submissions/detail/959982479/

/**
 * @param {Object} context
 * @param {any[]} args
 * @return {any}
 */
// ReSharper disable once NativeTypePrototypeExtending
Function.prototype.callPolyfill = function(context, ...args) {
    Object.defineProperty(context,
        "___fn",
        {
            value: this
        });
    const ans = context.___fn(...args);
    delete context.___fn;
    return ans;
}
