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
