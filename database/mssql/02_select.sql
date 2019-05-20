use [TestDb]

-- select all
select *
from [TestDb].[dbo].[TUser]

-- select top
select top 3 [Id], [Login]
from [TUser]

-- select where
select [Id]
from [TUser]
where [Name] = 'jaron'

-- select distinct
select distinct [Name]
from [TUser]