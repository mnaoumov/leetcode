-- https://leetcode.com/submissions/detail/936737793/

WITH cte AS (
    SELECT
        log_id,
        group_id = log_id - ROW_NUMBER() OVER (ORDER BY log_id)
    FROM Logs
)
SELECT
    start_id = MIN(log_id),
    end_id = MAX(log_id)
FROM cte
GROUP BY group_id
ORDER BY group_id;
