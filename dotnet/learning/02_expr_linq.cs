using System.Linq;

public class expr_linq
{
    class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    static User[] users = new User[]
    {
        new User { ID = 1, Name = "John", Age = 12 },
        new User { ID = 1, Name = "John Doe", Age = 13 },
        new User { ID = 2, Name = "Tom", Age = 23 },
        new User { ID = 4, Name = "Jack", Age = 22 },
        new User { ID = 5, Name = "Smith", Age = 22 },
    };

    static void group_by()
    {
        // `group u by u.ID into g` 表示
        // 对 `u` 按 `ID` 字段归类，其结果命名为 `g`，
        // 一旦重新命名，`u` 的作用域就结束了
        // 所以最后 `select` 时，只能 `select g`
        var r1 = from u in users
                 group u by u.ID into g
                 select g;
        foreach (var item in r1)
        {
            utils.print("[");
            foreach (var u in item)
                utils.print(u);
            utils.println("]");
        }

        // 获取每个分组的最大年龄项
        // 取出 ID 值，并把 UnitPrice 值赋给 MaxAge 
        var r2 = from u in users
                 group u by u.ID into g
                 select new {
                     g.Key,
                     MaxAge = g.Max(u => u.Age)
                 };
        foreach (var item in r2)
            utils.println(item);

        // 获取指定列
        var r3 = from u in users
                 group u by new {
                    u.ID, 
                    u.Name
                 } into g
                 select new {
                     g.Key,
                     g
                 };
        foreach (var item in r3)
            utils.println(item.g.Key);
    }

    public static void run()
    {
        group_by();

        // TODO: more
    }
}