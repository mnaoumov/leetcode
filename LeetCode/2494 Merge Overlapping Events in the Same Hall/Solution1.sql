-- https://leetcode.com/submissions/detail/870774468/

;WITH
cte1 AS
(
    SELECT
        hall_id,
        start_day,
        end_day,
        MAX(end_day) OVER(
            PARTITION BY hall_id
            ORDER BY
                start_day,
                end_day
            ROWS BETWEEN UNBOUNDED PRECEDING AND 1 PRECEDING
        ) AS max_end_day
    FROM dbo.HallEvents
),
cte2 AS
(
    SELECT
        hall_id,
        start_day,
        end_day,
        IIF(
            start_day > max_end_day OR max_end_day IS NULL,
            1,
            0
        ) AS ind
    FROM cte1
),
cte3 AS
(
    SELECT
        hall_id,
        start_day,
        end_day,
        SUM(ind) OVER(
            PARTITION BY hall_id
            ORDER BY
                start_day,
                end_day
        ) AS sum_ind
    FROM cte2
),
cte4 AS
(
    SELECT
        hall_id,
        MIN(start_day) AS start_day,
        MAX(end_day) AS end_day
    FROM cte3
    GROUP BY
        hall_id,
        sum_ind
)
SELECT
    hall_id,
    start_day,
    end_day
FROM cte4
ORDER BY
    hall_id,
    start_day,
    end_day