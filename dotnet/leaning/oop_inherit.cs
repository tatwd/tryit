class oop_inherit
{
    class A {
        public int id { get; set; }
        public string name { get; set; }
    }

    class B : A {
        public int age { get; set; }
    }

    public static void run()
    {
        A a = new B{ id = 1, name = "jaron" };
        // B b = (B)a; // error
        utils.println(a);
    }
}