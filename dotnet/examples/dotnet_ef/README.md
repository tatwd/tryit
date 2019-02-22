First of all:

```bash
dotnet add package Microsoft.EntityFrameworkCore.Design
```

then add the database provider reference that you need, e.g.
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

1. Database first:

```bash
dotnet ef dbcontext scaffold "Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models
```

or:

```bash
dotnet ef dbcontext scaffold "Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -t Blog -t Post --context-dir Context -c BlogContext

```