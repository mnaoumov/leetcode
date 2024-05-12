-- https://leetcode.com/submissions/detail/938085640/

WITH cte AS (
    SELECT
        user_id,
        window = DATEDIFF(day, visit_date, COALESCE(LEAD(visit_date) OVER(PARTITION BY user_id ORDER BY visit_date), '2021-01-01'))
    FROM UserVisits
)
SELECT
    user_id,
    biggest_window = MAX(window)
FROM cte
GROUP BY user_id;
