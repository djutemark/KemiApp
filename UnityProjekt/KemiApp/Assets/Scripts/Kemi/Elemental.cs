using UnityEngine;
using System.Collections;

public class Elemental
{
    protected char[] symbol;
    protected uint atomicNumber;
    protected double molarMass;

    public Elemental(char[] Symbol, uint atomicNumber, double molarMass)
    {
        symbol = Symbol;
        this.atomicNumber = atomicNumber;
        this.molarMass = molarMass;
    }

    protected Elemental() { }
}
