-- https://leetcode.com/submissions/detail/940721642/

WITH cte AS
(
    SELECT
        n1.num,
        min_index = COALESCE(SUM(n2.frequency), 0) + 1,
        max_index = COALESCE(SUM(n2.frequency), 0) + n1.frequency
    FROM Numbers AS n1
    LEFT JOIN Numbers AS n2 ON n2.num < n1.num
    GROUP BY
        n1.num,
        n1.frequency
),
cte2 AS
(
    SELECT
        medianIndex1 = (MAX(max_index) + 1) / 2,
        medianIndex2 = MAX(max_index) / 2 + 1
    FROM cte
),
cte3 AS
(
    SELECT
        median1 = cte.num
    FROM cte
    WHERE
        (SELECT medianIndex1 FROM cte2) BETWEEN cte.min_index AND cte.max_index
),
cte4 AS
(
    SELECT
        median2 = cte.num
    FROM cte
    WHERE
        (SELECT medianIndex2 FROM cte2) BETWEEN cte.min_index AND cte.max_index
)
SELECT
    median = ROUND((cte3.median1 + cte4.median2) / 2.0, 1)
FROM
    cte3,
    cte4;
