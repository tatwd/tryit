public class dispose_pattern
{
    class Dog : System.IDisposable
    {
        public void Dispose()
        {
            System.Console.WriteLine("Dispose invoked!");
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) {
                // 释放托管资源
            }
            // 释放非托管资源
        }

        ~Dog()
        {
            System.Console.WriteLine("~Dog invoked!");
            Dispose(false);
        }
    }

    [Xunit.Fact]
    public void run()
    {
        using (var dog1 = new Dog())
        {
        }
    }
}