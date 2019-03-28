// 反射
class reflection
{
    class Dog
    {
        public string Greet { get; set; } = "Wo Wo!";
        public string Eat(string food) { return "I am eating " + food; }
        public void Hi() { System.Console.WriteLine(Greet); }
    }

    // Get the type infomations
    static void get_type_info()
    {
        // compile time
        System.Type t1 = typeof(Dog);

        // runtime
        var dog = new Dog{ Greet = "Woo!" };
        System.Type t2 = dog.GetType();

        System.Console.WriteLine(t1.Name);
        System.Console.WriteLine(t2.Assembly);

    }

    // Get a instance of a type
    static void create_a_instance()
    {
        // use Activator
        var dog1 = (Dog)System.Activator.CreateInstance(typeof(Dog));
        dog1.Hi();

        var dog2 = System.Activator.CreateInstance<Dog>();
        dog2.Hi();

        // use default constructor
        // without defined parameters
        // var dogCtor = typeof(Dog).GetConstructor(new System.Type[0]);
        var dogCtor = typeof(Dog).GetConstructors()[0];
        var dog3 = (Dog)dogCtor.Invoke(null);
        dog3.Hi();
    }

    // Access a property
    static void access_property()
    {
        var dog = new Dog{ Greet = "Wooo!" };
        var type = dog.GetType();

        // get a property
        System.Reflection.PropertyInfo property = type.GetProperty("Greet");
        string value = (string)property.GetValue(dog);
        System.Console.WriteLine(value);

        // change the value
        property.SetValue(dog, "Woooo Woooo!");
        dog.Hi();
    }

    // Invok a method
    static void invoke_method()
    {
        var dog = new Dog();
        var type = dog.GetType();

        System.Reflection.MethodInfo hi = type.GetMethod("Hi");
        hi.Invoke(dog, null);

        // add parameter and reture value
        System.Reflection.MethodInfo eat = type.GetMethod("Eat");
        string result = (string)eat.Invoke(dog, new []{ "apple" });
        System.Console.WriteLine(result);
    }

    public static void run()
    {
        get_type_info();
        create_a_instance();
        access_property();
        invoke_method();
    }
}