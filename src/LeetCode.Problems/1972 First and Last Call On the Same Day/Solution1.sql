-- https://leetcode.com/submissions/detail/939060931/

WITH cte AS (
    SELECT
        caller_id,
        recipient_id,
        call_time
    FROM Calls

    UNION ALL

    SELECT
        caller_id = recipient_id,
        recipient_id = caller_id,
        call_time
    FROM Calls
),
cte2 AS (
    SELECT
        caller_id,
        min_call_time = MIN(call_time),
        max_call_time = MAX(call_time)
    FROM cte
    GROUP BY
        CAST(call_time AS date),
        caller_id
)
SELECT DISTINCT user_id = cte2.caller_id
FROM cte2
JOIN cte ON
    cte.caller_id = cte2.caller_id
    AND cte.call_time = cte2.min_call_time
JOIN cte AS cte3 ON
    cte3.caller_id = cte2.caller_id
    AND cte3.call_time = cte2.max_call_time
    AND cte3.recipient_id = cte.recipient_id;
