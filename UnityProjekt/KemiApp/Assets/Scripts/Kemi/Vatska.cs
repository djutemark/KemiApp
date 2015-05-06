using UnityEngine;
using System.Collections;

public class Vatska
{
    protected Grundamne[] beståndsdelar;
    protected string formel;
    protected double volym, koncentration;

    public Vatska(Grundamne[] Beståndsdelar, string Formel, double Volym, double Koncentration)
    {
        beståndsdelar = Beståndsdelar;
        formel = Formel;
        volym = Volym;
        koncentration = Koncentration;
    }
}

public class Syra : Vatska
{
    private double pH;

    public Syra(Grundamne[] beståndsdelar, string formel, double volym, double koncentration, double pH)
        : base(beståndsdelar, formel, volym, koncentration)
    {
        this.pH = pH;
    }
}
