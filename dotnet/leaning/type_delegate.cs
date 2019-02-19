class type_delegate
{
    delegate double Function(double x);

    static double[] map(double[] a, Function f)
    {
        double[] res = new double[a.Length];
        for (int i = 0; i < a.Length; i++) res[i] = f(a[i]);
        return res;
    }

    static double plus(double i)
    {
        return i * i;
    }

    public static void run()
    {
        double[] a = { 0.0, 0.5, 1.0 };
        double[] r1 = map(a, plus);
        double[] r2 = map(a, (i) => i + 1.0);
        utils.print(r1);
        utils.print(r2);
    }
}