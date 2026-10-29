-- https://leetcode.com/submissions/detail/933135283/

SELECT
    s1.id,
    student = COALESCE(s2.student, s1.student)
FROM Seat AS s1
LEFT JOIN Seat AS s2 ON s2.id = IIF(s1.id % 2 = 1, s1.id + 1, s1.id - 1)
ORDER BY s1.id;
