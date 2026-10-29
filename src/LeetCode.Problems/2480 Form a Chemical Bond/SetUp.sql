CREATE TABLE Elements
(
    symbol varchar(2),
    [type] varchar(8) NOT NULL CHECK ([type] IN ('Metal','Nonmetal','Noble')),
    electrons int
)