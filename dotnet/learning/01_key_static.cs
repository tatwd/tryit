class A {
    public A(string s) {
        System.Console.WriteLine(s);
    }
}

public class key_staic {
    static A a1 = new A("a1"); // 1
    A a2 = new A("a2"); // 3

    static key_staic() {
        a1 = new A("a3"); // 2
    }

    public key_staic() {
        a2 = new A("a4"); // 4
    }

    [Xunit.Fact]
    public static void run() {
        new key_staic();
    }
}