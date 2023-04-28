-- SkipSolution: RuntimeError
-- https://leetcode.com/submissions/detail/940909317/

WITH cte AS
(
    SELECT
        name,
        continent,
        rn = ROW_NUMBER() OVER (PARTITION BY continent ORDER BY name)
    FROM Student
),
cte2 AS
(
    SELECT max_rn = MAX(rn)
    FROM cte
),
cte3 AS
(
    SELECT rn = 1

    UNION ALL

    SELECT rn = rn + 1
    FROM cte3
    WHERE rn < (SELECT max_rn FROM cte2)
)
SELECT
    America = America.name,
    Asia = Asia.name,
    Europe = Europe.name
FROM cte3
LEFT JOIN cte AS America
    ON America.rn = cte3.rn
    AND America.continent = 'America'
LEFT JOIN cte AS Asia
    ON Asia.rn = cte3.rn
    AND Asia.continent = 'Asia'
LEFT JOIN cte AS Europe
    ON Europe.rn = cte3.rn
    AND Europe.continent = 'Europe';
