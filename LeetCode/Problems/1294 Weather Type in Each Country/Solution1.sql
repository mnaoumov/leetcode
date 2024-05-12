-- SkipSolution: WrongAnswer
-- https://leetcode.com/submissions/detail/933126435/

SELECT
    c.country_name,
    weather_type = CASE
        WHEN AVG(w.weather_state) <= 15 THEN 'Cold'
        WHEN AVG(w.weather_state) >= 25 THEN 'Hot'
        ELSE 'Warm'
    END
FROM Countries AS c
JOIN Weather AS w ON w.country_id = c.country_id
WHERE w.day BETWEEN '2019-11-01' AND '2019-11-30'
GROUP BY c.country_name;
