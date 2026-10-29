-- https://leetcode.com/submissions/detail/933441965/

SELECT c.seat_id
FROM Cinema AS c
JOIN Cinema AS c2 ON
    c2.seat_id IN (c.seat_id - 1, c.seat_id + 1)
    AND c2.free = 1
WHERE c.free = 1
GROUP BY c.seat_id
ORDER BY c.seat_id;
