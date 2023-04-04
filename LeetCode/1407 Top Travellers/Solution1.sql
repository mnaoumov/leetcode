-- https://leetcode.com/submissions/detail/927633549/

SELECT
    u.name,
    r.travelled_distance
FROM Users AS u
CROSS APPLY
(
    SELECT travelled_distance = COALESCE(SUM(distance), 0)
    FROM Rides AS r
    WHERE r.user_id = u.id
) AS r
ORDER BY
    r.travelled_distance DESC,
    u.name;
