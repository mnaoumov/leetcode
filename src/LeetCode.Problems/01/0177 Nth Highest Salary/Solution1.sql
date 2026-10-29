-- https://leetcode.com/submissions/detail/895658570/

CREATE FUNCTION getNthHighestSalary(@N INT) RETURNS INT AS
BEGIN
    DECLARE @result int;
    WITH distinctSalary AS
    (
        SELECT DISTINCT Salary
        FROM Employee
    ),
    withRowNumber AS
    (
        SELECT
            Salary,
            ROW_NUMBER() OVER(ORDER BY Salary DESC) as RowNumber
        FROM distinctSalary
    )
    SELECT @result = Salary
    FROM withRowNumber
    WHERE RowNumber = @N;

    RETURN @result;
END;
