using UnityEngine;
using System.Collections;

public enum MissionObjectives
{
    create,
    change,
    solve
}

public class Mission {

    private string header, missionText;
    private Objective[] objectives;

    public Mission()
    {
        // Constructor, do something if neccesarry which it isnt at the moment
        // Need this one for creating a object with empty parameters
    }

    public Mission(string header, string missionText, Objective[] objectives)
    {
        this.header = header;
        this.missionText = missionText;
        this.objectives = objectives;
    }

    public string Header
    {
        set { header = value; }
        get { return header; }
    }

    public string MissionText
    {
        set { missionText = value; }
        get { return missionText; }
    }

    public Objective[] Objectives
    {
        set { objectives = value; }
        get { return objectives; }
    }
}

public class Objective
{
    private string[] description;
    private bool[] lista;

    public Objective(string[] description, bool[] lista)
    {
        this.description = description;
        this.lista = lista;

    }

    public string[] Description
    {
        set { description = value; }
        get { return description; }
    }

    public bool[] Lista
    {
        set { lista = value; }
        get { return lista; }
    }

}