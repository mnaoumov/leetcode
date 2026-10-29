-- https://leetcode.com/submissions/detail/930380115/

WITH userCount AS (
    SELECT count = COUNT(1)
    FROM Users
),
cte AS (
    SELECT
        contest_id,
        percentage = CAST(100.0 * COUNT(1) / (SELECT count FROM userCount) AS numeric(36, 2))
    FROM Register
    GROUP BY contest_id
)
SELECT
    contest_id,
    percentage
FROM cte
ORDER BY
    percentage DESC,
    contest_id ASC;
