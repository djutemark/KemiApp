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
    private bool completed;

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
        completed = false;
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
    public bool Completed
    {
        set { completed = value; }
        get { return completed; }
    }
}

public class Objective
{
    private string description;
    private Actions action;

    public Objective(string description, Actions action)
    {
        this.description = description;
        this.action = action;

        // Things to do if special actions is wanted such as chek inbox
        switch (action)
        {
            case Actions.getItemsInbox:
                GameObject.FindGameObjectWithTag("Handlers").transform.FindChild("Mission Handler").GetComponent<MissionHandler>().Inbox = true;
                break;
            default:
                break;
        }

    }

    public string Description
    {
        set { description = value; }
        get { return description; }
    }

    public Actions Action
    {
        set { action = value; }
        get { return action; }
    }

}