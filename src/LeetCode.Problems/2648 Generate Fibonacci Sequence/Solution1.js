// https://leetcode.com/submissions/detail/957327546/

/**
 * @return {Generator<number>}
 */
var fibGenerator = function*() {
    let x = 0;
    let y = 1;

    yield x;

    while (true) {
        yield y;
        [x, y] = [y, x + y];
    }
};

module.exports = fibGenerator;
