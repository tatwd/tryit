class expr_try_catch_finaly
{
    static int? question1()
    {
        try
        {
            System.Console.Write("a: ");
            int a = System.Convert.ToInt32(System.Console.ReadLine());
            System.Console.Write("b: ");
            int b = System.Convert.ToInt32(System.Console.ReadLine());
            return a / b;
        }
        catch (System.DivideByZeroException ex)
        {
            utils.print("DivideByZeroException: {0}", ex.Message);
        }
        catch (System.FormatException ex)
        {
            utils.print("FormatException: {0}", ex.Message);
        }
        catch (System.Exception ex) // `Exception` should catch lastly
        {
            utils.print("Exception: {0}", ex.Message);
        }
        return null;
    }

    static int question2()
    {
        try
        {
            System.Console.Write("a: ");
            int a = System.Convert.ToInt32(System.Console.ReadLine());
            System.Console.Write("b: ");
            int b = System.Convert.ToInt32(System.Console.ReadLine());
            return a / b;
        }
        catch (System.Exception ex)
        {
            utils.print("Exception: {0}", ex.Message);
        }
        finally
        {
            // Run this before return value
            utils.print("finaly run!");
        }
        return 0;
    }

    public static void run()
    {
        int? ans;

        ans = question1();
        if (!ans.HasValue)
            utils.print("question1: no answer!");
        else
            utils.print("question1: ans is {0}.", ans);

        ans = question2();
        if (!ans.HasValue)
            utils.print("question2: no answer!");
        else
            utils.print("question2: ans is {0}.", ans);
    }
}