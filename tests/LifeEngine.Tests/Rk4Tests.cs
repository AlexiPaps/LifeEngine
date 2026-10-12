using LifeEngine.Core;

namespace LifeEngine.Tests;

public class Rk4Tests
{
    [Fact]
    public void Solves_exponential_decay()
    {
        double[] y = Rk4.Solve((t, y) => [-0.05 * y[0]], 0, [1.0], 10, 120);

        Assert.Equal(Math.Exp(-0.5), y[0], 1e-10);
    }

    [Fact]
    public void Survival_ode_matches_Makeham_closed_form()
    {
        var G82 = new MakehamIntensity(0.0005, 0.00005, Math.Pow(10, 0.038));

        double[] p = Rk4.Solve((t, p) => [-G82.Mu(40 + t) * p[0]], 0, [1.0], 10, 120);

        Assert.Equal(G82.Survival(40, 10), p[0], 1e-10);
    }

    [Fact]
    public void Halving_the_step_reduces_error_by_about_16()
    {
        double Error(int steps) =>
            Math.Abs(Rk4.Solve((t, y) => [-y[0]], 0, [1.0], 1, steps)[0] - Math.Exp(-1));

        double order = Math.Log2(Error(10) / Error(20));

        Assert.InRange(order, 3.9, 4.1);
    }
}