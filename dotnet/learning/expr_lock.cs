class expr_lock
{
    decimal balance;

    void withdraw(decimal amount)
    {
        lock(this)
        {
            if (amount > balance)
            {
                throw new System.Exception("amount > balance");
            }
            balance -= amount;
        }
    }

    public static void run()
    {
        var expr = new expr_lock
        {
            balance = 5m
        };
        expr.withdraw(1m);
        System.Console.WriteLine(expr.balance);
    }
}