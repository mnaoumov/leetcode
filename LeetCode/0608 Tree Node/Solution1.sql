-- https://leetcode.com/submissions/detail/925201897/

SELECT
    node.id,
    type = CASE
        WHEN node.p_id IS NULL
            THEN 'Root'
        WHEN EXISTS(
            SELECT 1
            FROM Tree as child
            WHERE child.p_id = node.id
        )
            THEN 'Inner'
        ELSE
            'Leaf'
    END
FROM Tree AS node;
