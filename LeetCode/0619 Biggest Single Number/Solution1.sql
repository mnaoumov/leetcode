-- https://leetcode.com/submissions/detail/930947855/

WITH cte AS (
    SELECT num
    FROM MyNumbers
    GROUP BY num
    HAVING COUNT(1) = 1
)
SELECT num = MAX(num)
FROM cte;
