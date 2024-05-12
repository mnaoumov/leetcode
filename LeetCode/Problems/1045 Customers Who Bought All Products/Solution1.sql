-- SkipSolution: WrongAnswer
-- https://leetcode.com/submissions/detail/934952060/

SELECT c.customer_id
FROM Customer AS c
GROUP BY c.customer_id
HAVING COUNT(1) = (SELECT COUNT(1) FROM Product);
