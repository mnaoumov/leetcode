// https://leetcode.com/submissions/detail/943866493/

/**
 * @param {number} millis
 */
async function sleep(millis) {
    return new Promise((resolve) => {
        setTimeout(resolve, millis);
    });
}
