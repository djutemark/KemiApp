using UnityEngine;
using System.Collections;

public class Amne : Grundamne
{
    protected Grundamne[] beståndsdelar;
    protected string formel;
    private double massa, substansmängd;

    public Amne(Grundamne[] Beståndsdelar, string Formel, double Massa, double Substansmängd)
    {
        formel = Formel;
        beståndsdelar = Beståndsdelar;
        massa = Massa;
        substansmängd = Substansmängd;
    }

    protected Amne() { }
}