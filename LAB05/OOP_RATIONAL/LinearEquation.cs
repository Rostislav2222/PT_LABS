using System;
using System.Text;

public class LinearEquation
{
    private double[] coefficients;
    private double b;

    public double[] Coefficients
    {
        get { return coefficients; }
        set { coefficients = value; }
    }

    public double B
    {
        get { return b; }
        set { b = value; }
    }

    public LinearEquation(double[] coefficients, double b)
    {
        this.coefficients = coefficients;
        this.b = b;
    }

    public static LinearEquation operator +(LinearEquation eq1, LinearEquation eq2)
    {
        if (eq1.coefficients.Length != eq2.coefficients.Length)
            throw new ArgumentException("Уравнения должны иметь одинаковое количество переменных");

        double[] newCoeffs = new double[eq1.coefficients.Length];
        for (int i = 0; i < newCoeffs.Length; i++)
        {
            newCoeffs[i] = eq1.coefficients[i] + eq2.coefficients[i];
        }
        double newB = eq1.b + eq2.b;
        return new LinearEquation(newCoeffs, newB);
    }

    public static LinearEquation operator -(LinearEquation eq1, LinearEquation eq2)
    {
        if (eq1.coefficients.Length != eq2.coefficients.Length)
            throw new ArgumentException("Уравнения должны иметь одинаковое количество переменных");

        double[] newCoeffs = new double[eq1.coefficients.Length];
        for (int i = 0; i < newCoeffs.Length; i++)
        {
            newCoeffs[i] = eq1.coefficients[i] - eq2.coefficients[i];
        }
        double newB = eq1.b - eq2.b;
        return new LinearEquation(newCoeffs, newB);
    }

    public override string ToString()
    {
        if (coefficients == null || coefficients.Length == 0)
            return "0 = " + b;

        StringBuilder sb = new StringBuilder();
        bool firstTerm = true;

        for (int i = 0; i < coefficients.Length; i++)
        {
            double coef = coefficients[i];
            if (coef == 0)
                continue;

            string sign = "";
            string term = "";

            if (coef > 0)
            {
                if (!firstTerm)
                    sign = " + ";
                else if (coef == 1)
                    term = "x" + (i + 1);
                else
                    term = coef + "x" + (i + 1);
            }
            else
            {
                sign = firstTerm ? "-" : " - ";
                coef = Math.Abs(coef);
                term = (coef == 1) ? "x" + (i + 1) : coef + "x" + (i + 1);
            }

            if (firstTerm && coef > 0)
            {
                sb.Append(term);
            }
            else
            {
                sb.Append(sign + term);
            }

            firstTerm = false;
        }

        if (sb.Length == 0)
            sb.Append("0");

        sb.Append(" = " + b);
        return sb.ToString();
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        LinearEquation other = (LinearEquation)obj;
        return this.coefficients.Length == other.coefficients.Length;
    }
}