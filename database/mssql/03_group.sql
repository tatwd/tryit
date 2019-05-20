use [TestDb]

-- group by one field
select [Id]
from [TUser]
group by [Id]

-- group by fields
select [Id], [Login]
from [TUser]
group by [Id], [Login]