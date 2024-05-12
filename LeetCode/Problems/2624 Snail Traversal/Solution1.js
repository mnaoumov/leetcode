// https://leetcode.com/submissions/detail/946358546/

/**
 * @param {number} rowsCount
 * @param {number} colsCount
 * @return {Array<Array<number>>}
 */
// ReSharper disable once NativeTypePrototypeExtending
Array.prototype.snail = function(rowsCount, colsCount) {
    const length = rowsCount * colsCount;

    if (length !== this.length) {
        return [];
    }

    const ans = [];

    for (let i = 0; i < rowsCount; i++) {
        ans.push([]);
    }

    let rowIndex = 0;
    let direction = 1;

    for (let i = 0; i < length; i++) {
        ans[rowIndex].push(this[i]);
        rowIndex += direction;
        if (rowIndex === rowsCount || rowIndex < 0) {
            direction = -direction;
            rowIndex += direction;
        }
    }

    return ans;
}
