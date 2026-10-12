namespace LifeEngine.Core;

/// <summary>Classical fourth-order Runge–Kutta with a fixed step for y'(t) = f(t, y).</summary>
public static class Rk4
{
    public static double[] Solve(Func<double, double[], double[]> f, double t0, double[] y0, double t1, int steps)
    {
        double h = (t1 - t0) / steps;
        double[] y = y0;

        for (int i = 0; i < steps; i++)
        {
            y = Step(f, t0 + i * h, y, h);
        }

        return y;
    }

    private static double[] Step(Func<double, double[], double[]> f, double t, double[] y, double h)
    {
        double[] k1 = f(t, y);
        double[] k2 = f(t + h / 2, Add(y, k1, h / 2));
        double[] k3 = f(t + h / 2, Add(y, k2, h / 2));
        double[] k4 = f(t + h, Add(y, k3, h));

        var next = new double[y.Length];
        for (int j = 0; j < y.Length; j++)
        {
            next[j] = y[j] + h / 6 * (k1[j] + 2 * k2[j] + 2 * k3[j] + k4[j]);
        }

        return next;
    }

    private static double[] Add(double[] y, double[] k, double scale)
    {
        var result = new double[y.Length];
        for (int j = 0; j < y.Length; j++)
        {
            result[j] = y[j] + scale * k[j];
        }

        return result;
    }
}