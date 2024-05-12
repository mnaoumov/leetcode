-- https://leetcode.com/submissions/detail/923944621/

DELETE
FROM Person
WHERE id IN
(
    SELECT DISTINCT p1.id
    FROM Person AS p1
    JOIN Person AS p2 ON p2.email = p1.email AND p1.id > p2.id
);
