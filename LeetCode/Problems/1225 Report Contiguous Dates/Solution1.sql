-- https://leetcode.com/submissions/detail/940741154/

WITH cte AS
(
    SELECT
        state = 'failed',
        date = fail_date
    FROM Failed

    UNION ALL

    SELECT
        state = 'succeeded',
        date = success_date
    FROM Succeeded
),
cte2 AS
(
    SELECT
        rn = ROW_NUMBER() OVER(ORDER BY state, date),
        state,
        date
    FROM cte
    WHERE YEAR(date) = 2019
)
SELECT
    period_state = state,
    start_date = CAST(MIN(date) AS char(10)),
    end_date = CAST(MAX(date) AS char(10))
from cte2
GROUP BY
    state,
    DATEADD(day, -rn, date)
ORDER BY MIN(date);
