using LifeEngine.Core;

namespace LifeEngine.Tests;

public class IntensityTests
{
    private static readonly MakehamIntensity G82 = new(0.0005, 0.00005, Math.Pow(10, 0.038));

    [Fact]
    public void Makeham_intensity_at_40_matches_hand_calculation()
    {
        Assert.Equal(0.0021557, G82.Mu(40), 1e-7);
    }

    [Fact]
    public void Makeham_survival_matches_hand_calculation()
    {
        Assert.Equal(0.969021, G82.Survival(40, 10), 1e-6);
    }

    [Fact]
    public void Survival_over_zero_years_is_one()
    {
        Assert.Equal(1.0, G82.Survival(40, 0), 1e-15);
    }

    [Fact]
    public void Makeham_without_age_term_equals_constant_intensity()
    {
        var makeham = new MakehamIntensity(0.01, 0.0, 1.1);
        var constant = new ConstantIntensity(0.01);

        Assert.Equal(constant.Survival(40, 10), makeham.Survival(40, 10), 1e-15);
    }
}