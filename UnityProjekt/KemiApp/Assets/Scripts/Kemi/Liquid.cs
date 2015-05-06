using UnityEngine;
using System.Collections;

public class Liquid
{
    protected Elemental[] ingredients;
    protected string formula;
    protected double volume, concentration;

    public Liquid(Elemental[] ingredients, string formula, double volume, double concentration)
    {
        this.formula = formula;
        this.ingredients = ingredients;
        this.volume = volume;
        this.concentration = concentration;
    }
}

public class Acid : Liquid
{
    private double pH;

    public Acid(Elemental[] ingredients, string formula, double volume, double concentration, double pH)
        : base(ingredients, formula, volume, concentration)
    {
        this.pH = pH;
    }
}
