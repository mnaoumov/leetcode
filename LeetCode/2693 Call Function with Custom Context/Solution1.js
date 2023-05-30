// SkipSolution: WrongAnswer
// https://leetcode.com/submissions/detail/959980837/

/**
 * @param {Object} context
 * @param {any[]} args
 * @return {any}
 */
// ReSharper disable once NativeTypePrototypeExtending
Function.prototype.callPolyfill = function(context, ...args) {
    context.___fn = this;
    const ans = context.___fn(...args);
    delete context.___fn;
    return ans;
}
