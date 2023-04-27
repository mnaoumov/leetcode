-- SkipSolution: WrongAnswer
-- https://leetcode.com/submissions/detail/940330563/

WITH cte AS (
    SELECT
        s.product_id,
        report_year = YEAR(s.period_start)
    FROM Sales AS s

    UNION ALL

    SELECT
        cte.product_id,
        report_year = cte.report_year + 1
    FROM cte
    JOIN Sales AS s ON s.product_id = cte.product_id
    WHERE cte.report_year < YEAR(s.period_end)
),
cte2 AS (
    SELECT
        cte.product_id,
        cte.report_year,
        min_year_date = DATEFROMPARTS(cte.report_year, 1, 1),
        max_year_date = DATEFROMPARTS(cte.report_year, 12, 31)
    FROM cte
),
cte3 AS (
    SELECT
        cte2.product_id,
        cte2.report_year,
        min_year_date = IIF(cte2.min_year_date < s.period_start, s.period_start, cte2.min_year_date),
        max_year_date = IIF(cte2.max_year_date > s.period_end, s.period_end, cte2.max_year_date)
    FROM cte2
    JOIN Sales AS s ON s.product_id = cte2.product_id
)
SELECT
    p.product_id,
    p.product_name,
    cte3.report_year,
    total_amount = s.average_daily_sales * (DATEDIFF(day, cte3.min_year_date, cte3.max_year_date) + 1)
FROM cte3
JOIN Sales AS s ON s.product_id = cte3.product_id
JOIN Product AS p ON p.product_id = s.product_id
ORDER BY
    p.product_id,
    cte3.report_year;
