// https://leetcode.com/submissions/detail/943598007/

// ReSharper disable once NativeTypePrototypeExtending
Array.prototype.last = function() {
    if (this.length === 0) {
        return -1;
    }

    return this[this.length - 1];
};
