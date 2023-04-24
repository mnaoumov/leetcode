-- https://leetcode.com/submissions/detail/938762848/

WITH cte AS (
    SELECT
        event_type,
        avg_occurences = AVG(1.0 * occurences)
    FROM Events
    GROUP BY event_type
),
cte2 AS (
    SELECT
        e.business_id,
        e.event_type
    FROM Events AS e
    JOIN cte ON cte.event_type = e.event_type
    WHERE e.occurences > cte.avg_occurences
)
SELECT business_id
FROM cte2
GROUP BY business_id
HAVING COUNT(1) > 1;
