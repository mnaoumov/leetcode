-- https://leetcode.com/submissions/detail/935940528/

WITH cte AS (
    SELECT
        player_id,
        min_event_date = MIN(event_date)
    FROM Activity
    GROUP BY player_id
)
SELECT fraction = ROUND(1.0 * COUNT(1) / (SELECT COUNT(DISTINCT player_id) FROM Activity), 2)
FROM cte
JOIN Activity AS a ON
    a.player_id = cte.player_id
    AND a.event_date = DATEADD(day, 1, cte.min_event_date);
