-- https://leetcode.com/submissions/detail/887780125/

SELECT
    p.firstName,
    p.lastName,
    a.city,
    a.state
FROM Person AS p
LEFT JOIN Address AS a ON
    a.personId = p.PersonId;