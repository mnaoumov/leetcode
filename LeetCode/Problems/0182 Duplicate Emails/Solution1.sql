-- https://leetcode.com/submissions/detail/899215265/

SELECT DISTINCT p1.email AS Email
FROM Person AS p1
JOIN Person AS p2 ON p2.email = p1.email AND p2.id > p1.id;