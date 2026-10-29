-- https://leetcode.com/submissions/detail/935993366/

WITH days AS (
    SELECT Day = '2013-10-01'
    UNION
    SELECT Day = '2013-10-02'
    UNION
    SELECT Day = '2013-10-03'
)
SELECT
    days.Day,
    [Cancellation Rate] = ROUND(SUM(IIF(t.status IN ('cancelled_by_driver', 'cancelled_by_client'), 1.0, 0.0)) / COUNT(1), 2)
FROM days
LEFT JOIN Trips AS t ON t.request_at = days.Day
JOIN Users AS client ON client.users_id = t.client_id
JOIN Users AS driver ON driver.users_id = t.driver_id
WHERE
    client.banned = 'No'
    AND driver.banned = 'No'
GROUP BY days.Day;
