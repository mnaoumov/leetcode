-- https://leetcode.com/submissions/detail/870709372/

SELECT
    person_id,
    name + '(' + SUBSTRING(profession, 1, 1) + ')' AS name
FROM Person
ORDER BY person_id DESC