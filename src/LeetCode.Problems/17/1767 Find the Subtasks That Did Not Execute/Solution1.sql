-- https://leetcode.com/submissions/detail/939688309/

WITH cte AS (
    SELECT DISTINCT
        task_id,
        subtask_id = 1
    FROM Tasks

    UNION ALL

    SELECT
        cte.task_id,
        subtask_id = cte.subtask_id + 1
    FROM cte
    JOIN Tasks AS t ON t.task_id = cte.task_id
    WHERE cte.subtask_id < t.subtasks_count
)
SELECT
    cte.task_id,
    cte.subtask_id
FROM cte
LEFT JOIN Executed AS e ON
    e.task_id = cte.task_id
    AND e.subtask_id = cte.subtask_id
WHERE e.task_id IS NULL;
