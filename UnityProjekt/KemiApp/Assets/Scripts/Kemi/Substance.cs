using UnityEngine;
using System.Collections;

public class Substance : Elemental
{
    protected Elemental[] ingredients;
    protected string formula;
    private double mass, amountOfSubstance;

    public Substance(Elemental[] ingredients, string formula, double mass, double amountOfSubstance)
    {
        this.formula = formula;
        this.ingredients = ingredients;
        this.mass = mass;
        this.amountOfSubstance = amountOfSubstance;
    }

    protected Substance() { }
}