-- https://leetcode.com/submissions/detail/930229739/

WITH cte AS (
    SELECT
        person1 = IIF(from_id < to_id, from_id, to_id),
        person2 = IIF(from_id < to_id, to_id, from_id),
        duration
    FROM Calls
)
SELECT
    person1,
    person2,
    call_count = COUNT(1),
    total_duration = SUM(duration)
FROM cte
GROUP BY
    person1,
    person2;

