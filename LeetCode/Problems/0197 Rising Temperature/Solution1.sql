-- https://leetcode.com/submissions/detail/926242304/

SELECT Id = w.id
FROM Weather AS w
JOIN Weather AS wYesterday ON wYesterday.recordDate = DATEADD(day, -1, w.recordDate)
WHERE w.temperature > wYesterday.temperature;
