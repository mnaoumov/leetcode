-- https://leetcode.com/submissions/detail/898674036/

SELECT DISTINCT l1.num AS ConsecutiveNums
FROM Logs AS l1
JOIN Logs AS l2 ON l2.id = l1.id + 1
JOIN Logs AS l3 ON l3.id = l2.id + 1
WHERE
    l2.num = l1.num
    AND l3.num = l1.num;