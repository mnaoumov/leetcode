-- https://leetcode.com/submissions/detail/940910519/

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
    SELECT DISTINCT rn
    FROM cte
)
SELECT
    America = America.name,
    Asia = Asia.name,
    Europe = Europe.name
FROM cte2
LEFT JOIN cte AS America
    ON America.rn = cte2.rn
    AND America.continent = 'America'
LEFT JOIN cte AS Asia
    ON Asia.rn = cte2.rn
    AND Asia.continent = 'Asia'
LEFT JOIN cte AS Europe
    ON Europe.rn = cte2.rn
    AND Europe.continent = 'Europe';
