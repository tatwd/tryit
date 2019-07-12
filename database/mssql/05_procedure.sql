-- 存储过程

-- 创建
-- create procedure <procedure_name> (<arguments>)
-- as begin <sql> end

create procedure mycout (
    @n int output
)
as
begin
    select @n = count(id)
    from t_student
end
go

-- 修改
-- alter procedure <procedure_name> (<arguments>)
-- as begin <sql> end

-- 删除
-- drop procedure <procedure_name>
drop procedure mycout
go


-- 分页
create procedure get_student_by_page (
    @page int = 1,
    @top int = 10
)
as
begin 
    select top (@top) * 
    from (
        select row_number() over(order by id asc) as 'row', * 
        from t_student
    ) as stu 
    where row > (@page - 1) * @top
end
