namespace LifeEngine.Core;

/// <summary>Transition intensity per year as a function of exact age in years.</summary>
public interface IIntensity
{
    double Mu(double age);
}

public sealed record ConstantIntensity(double Value) : IIntensity
{
    public double Mu(double age) => Value;

    /// <summary>Probability that a person aged <paramref name="age"/> survives <paramref name="t"/> more years.</summary>
    public double Survival(double age, double t) => Math.Exp(-Value * t);
}

/// <summary>Gompertz–Makeham intensity, mu(x) = A + B * C^x, with C &gt; 1.</summary>
public sealed record MakehamIntensity(double A, double B, double C) : IIntensity
{
    public double Mu(double age) => A + B * Math.Pow(C, age);

    /// <summary>Probability that a person aged <paramref name="age"/> survives <paramref name="t"/> more years.</summary>
    public double Survival(double age, double t) =>
        Math.Exp(-A * t - B / Math.Log(C) * Math.Pow(C, age) * (Math.Pow(C, t) - 1));
}