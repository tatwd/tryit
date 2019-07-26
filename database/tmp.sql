-- create table t_tmp (
--     x_id VARCHAR(20) not null,
--     type_code VARCHAR(20) not null
-- )

-- INSERT INTO t_tmp VALUES
-- ('HT16060347', 'PDM-5A'),
-- ('HT16060348', 'PDM-5A'),
-- ('HT16060349', 'PDM-20A'),
-- ('HT16060350', 'PDM-20A'),
-- ('HT16060360', 'PDM-20A'),
-- ('HT16060361', 'PDM-20A'),
-- ('HT16060362', 'PDM-20A')

-- select * from t_tmp

-- declare 
--     @start_x_id int,
--     @end_x_id int

-- select top 1 @start_x_id = CAST( RIGHT(x_id, len(x_id) - 2) AS int)
-- from t_tmp
-- where type_code='PDM-5A'

-- select @start_x_id

-- select top 1 x_id --@end_x_id = CAST( RIGHT(x_id, len(x_id) - 2) AS int) --x_id as 结束
-- from t_tmp
-- GROUP by type_code,x_id

/*
select #a.*, #b.*
from 
t_tmp #a
left join
(
    select 
        type_code 型号,
        MIN( CAST( RIGHT(x_id, len(x_id) - 2) AS int) ) 开始,
        MAX( CAST( RIGHT(x_id, len(x_id) - 2) AS int) ) 结束
    from t_tmp
    GROUP by type_code
) #b
on #a.type_code = #b.型号
*/

SELECT
    #a.type_code 型号,
    CONCAT('HT', MIN( CAST( RIGHT(x_id, len(x_id) - 2) AS INT) ) ) 开始,
    CONCAT('HT', MAX( CAST( RIGHT(x_id, len(x_id) - 2) AS INT) ) ) 结束,
    COUNT(1) 个数
FROM
(
    SELECT x_id, type_code, cnt = CAST( RIGHT(x_id, len(x_id) - 2) AS INT) - ROW_NUMBER() OVER(ORDER BY type_code DESC)
    FROM t_tmp
) #a
GROUP by #a.type_code, #a.cnt
ORDER BY 开始