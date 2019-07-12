-- 分页

DECLARE
     @page int = 1000,
     @top int = 100

-- 获取分页数据
SELECT TOP (@top) *
FROM test_db.dbo.t_record #a
WHERE #a.id > (
    -- 定位到起始 ID
    SELECT TOP 1 id
    FROM (
        -- 构建含行号的临时表
        SELECT id, ROW_NUMBER() OVER(ORDER BY id ASC) AS row_num
        FROM test_db.dbo.t_record
    ) AS #b
    WHERE #b.row_num = (@page-1) * @top
)
GO