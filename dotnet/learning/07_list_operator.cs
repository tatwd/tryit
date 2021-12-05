public class list_operator
{

    [Xunit.Fact]
    public static void run()
    {
        System.Collections.Generic.IList<string> list =
            new System.Collections.Generic.List<string>
        {
            "1", "2", "1", "3"
        };
        // list.Add("1");
        // list.Add("2");

        // 无法删除连续的重复元素
        // for (int i = 0; i < list.Count; i++)
        // {
        //     if (list[i] == "1")
        //         list.RemoveAt(i); /* 此时 list.Count 发生改变 */
        // }

        // 控制 i++
        // for (int i = 0; i < list.Count;)
        // {
        //     if (list[i] == "1")
        //         list.RemoveAt(i);
        //     else
        //         i++;
        // }

        // 或倒序遍历增删
        // for (int i = list.Count - 1; i >= 0; i--)
        // {
        //     if (list[i] == "1")
        //         list.RemoveAt(i);
        // }

        // 发生异常 System.InvalidOperationException:
        // Collection was modified; enumeration operation may not execute.
        // foreach (var item in list) /* foreach 实际是利用 IEnumerator */
        // {
        //     if (item == "1")
        //         list.Remove(item);
        // }

        System.Collections.Generic.IEnumerator<string> itr =
            list.GetEnumerator();
        while(itr.MoveNext())
        {
            System.Console.WriteLine(itr.Current);
            if (itr.Current.Equals("1"))
            {
                list.Remove(itr.Current); /* itr 发生改变 */
                itr = list.GetEnumerator(); /* 效率太低 */
            }
        }

        foreach(var i in list)
            System.Console.WriteLine(i);
	}
}
