-- https://leetcode.com/submissions/detail/931321735/

SELECT
    left_operand,
    operator,
    right_operand,
    value = CASE e.operator
        WHEN '<' THEN IIF(vLeft.value < vRight.value, 'true', 'false')
        WHEN '>' THEN IIF(vLeft.value > vRight.value, 'true', 'false')
        WHEN '=' THEN IIF(vLeft.value = vRight.value, 'true', 'false')
    END
FROM Expressions AS e
JOIN Variables AS vLeft ON vLeft.name = e.left_operand
JOIN Variables AS vRight ON vRight.name = e.right_operand;
