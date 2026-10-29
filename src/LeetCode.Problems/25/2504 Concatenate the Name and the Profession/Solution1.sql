-- https://leetcode.com/submissions/detail/869962832/

SELECT
    person_id,
    CONCAT(name, '(', SUBSTRING(profession, 1, 1), ')') AS name
FROM Person
ORDER BY person_id DESC