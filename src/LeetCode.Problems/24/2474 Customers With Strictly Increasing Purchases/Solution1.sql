-- https://leetcode.com/submissions/detail/874641548/

;WITH
cte1 AS
(
    SELECT
        customer_id,
        price,
        year = DATEPART(year, order_date)
    FROM Orders
),
cte2 AS
(
    SELECT
        customer_id,
        min_year = MIN(year) OVER(PARTITION BY customer_id),
        max_year = MAX(year) OVER(PARTITION BY customer_id),
        year,
        year_total_price = SUM(price),
        year_count = COUNT(year) OVER(PARTITION BY customer_id)
    FROM cte1
    GROUP BY
        customer_id,
        year
),
cte3 AS
(
    SELECT
        customer_id,
        year,
        year_total_price,
        year_count,
        max_year
    FROM cte2
    WHERE year_count = max_year - min_year + 1
),
cte4 AS
(
    SELECT
        x.customer_id,
        x.year,
        x.year_total_price,
        next_year_total_price = COALESCE(y.year_total_price, 0),
        x.year_count,
        x.max_year
    FROM cte3 as x
    LEFT JOIN cte3 AS y ON
        y.customer_id = x.customer_id
        and y.year = x.year + 1
),
cte5 AS
(
    SELECT
        customer_id,
        year_count,
        increasing_year_flag = IIF(year = max_year OR next_year_total_price > year_total_price, 1, 0)
    FROM cte4
),
cte6 AS
(
    SELECT
        customer_id,
        year_count,
        increasing_years_count = SUM(increasing_year_flag) OVER(PARTITION BY customer_id)
    FROM cte5
)
SELECT customer_id
FROM cte6
WHERE increasing_years_count = year_count
GROUP BY customer_id