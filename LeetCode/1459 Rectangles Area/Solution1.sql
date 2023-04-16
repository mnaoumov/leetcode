-- https://leetcode.com/submissions/detail/934398688/

WITH cte AS
(
    SELECT
        P1 = p1.id,
        P2 = p2.id,
        AREA = ABS(p1.x_value - p2.x_value) * ABS(p1.y_value - p2.y_value)
    FROM
        Points AS p1,
        Points AS p2
    WHERE p2.id > p1.id
)
SELECT
    P1,
    P2,
    AREA
FROM cte
WHERE area > 0
ORDER BY
    area DESC,
    p1,
    p2;
