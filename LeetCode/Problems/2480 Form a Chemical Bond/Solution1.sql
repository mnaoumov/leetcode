-- https://leetcode.com/submissions/detail/871219652/

SELECT
    metal.symbol AS metal,
    nonmetal.symbol AS nonmetal
FROM
    Elements AS metal,
    Elements AS nonmetal
WHERE
    metal.[type] = 'Metal'
    AND nonmetal.[type] = 'Nonmetal'