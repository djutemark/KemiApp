using UnityEngine;
using System.Collections;

public class Grundamne
{
    protected char[] symbol;
    protected uint atomNummer;
    protected double molmassa;

    public Grundamne(char[] Symbol, uint AtomNummer, double Molmassa)
    {
        symbol = Symbol;
        atomNummer = AtomNummer;
        molmassa = Molmassa;
    }

    protected Grundamne() { }
}
