-- https://leetcode.com/submissions/detail/927629901/

WITH stockNames AS
(
    SELECT DISTINCT stock_name
    FROM Stocks
)
SELECT
    sn.stock_name,
    capital_gain_loss = gainLoss.value
FROM stockNames AS sn
CROSS APPLY
(
    SELECT value = SUM(s.price * IIF(s.operation = 'Sell', 1, -1))
    FROM Stocks AS s
    WHERE s.stock_name = sn.stock_name
) AS gainLoss;
