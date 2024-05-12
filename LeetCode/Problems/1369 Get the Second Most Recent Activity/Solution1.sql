-- https://leetcode.com/submissions/detail/938776126/

WITH cte AS (
    SELECT
        username,
        activity,
        startDate,
        endDate,
        rn = ROW_NUMBER() OVER(PARTITION BY username ORDER BY startDate DESC)
    FROM UserActivity
)
SELECT
    cte.username,
    cte.activity,
    cte.startDate,
    cte.endDate
FROM cte
LEFT JOIN cte AS cte2 ON
    cte2.username = cte.username 
    AND cte2.rn = 2
WHERE
    cte.rn = 2
    OR cte2.username IS NULL;
