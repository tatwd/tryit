-- 类型转换
-- CAST(<variable> AS <dtype>)
-- CONVERT(<dtype>, <variable>, <style>)
declare @v int = 12,
        @t datetime = getdate();

select cast(@v as varchar) as 'v_string'
       cast(@t as varchar) as 't_string'

select convert(varchar, @v) as 'v_string',
       convert(datetime2, @t) as 't_dt2';
