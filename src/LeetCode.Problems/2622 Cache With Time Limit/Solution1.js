// https://leetcode.com/submissions/detail/946288918/

// ReSharper disable once InconsistentNaming
var TimeLimitedCache = function() {
    this.valuesMap = new Map();
    this.timeoutsMap = new Map();
};

/** 
 * @param {number} key
 * @param {number} value
 * @param {number} time until expiration in ms
 * @return {boolean} if un-expired key already existed
 */
TimeLimitedCache.prototype.set = function(key, value, duration) {
    const isNew = !this.timeoutsMap.has(key);

    if (!isNew) {
        const previousTimeoutId = this.timeoutsMap.get(key);
        if (previousTimeoutId !== null) {
            clearTimeout(previousTimeoutId);
        }
    }

    this.valuesMap.set(key, value);
    const timeoutId = setTimeout(() => {
        this.timeoutsMap.delete(key);
        this.valuesMap.delete(key);
    }, duration);

    this.timeoutsMap.set(key, timeoutId);

    return !isNew;
};

/** 
 * @param {number} key
 * @return {number} value associated with key
 */
TimeLimitedCache.prototype.get = function(key) {
    return this.valuesMap.has(key) ? this.valuesMap.get(key) : -1;
};

/** 
 * @return {number} count of non-expired keys
 */
TimeLimitedCache.prototype.count = function() {
    return this.valuesMap.size;
};

module.exports = TimeLimitedCache;
