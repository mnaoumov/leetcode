-- https://leetcode.com/submissions/detail/923925112/

SELECT
    name,
    population,
    area
FROM World
WHERE
   area >= 3000000
   OR population >= 25000000;
