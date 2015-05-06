using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionHandler : MonoBehaviour {
    public GameObject missionButtonsText;

    private GameObject inbox, UI, canvas;
    private Mission mission;
    public Mission[] missions;          // Later on, make this private
    private Character player;

    private double timer, cooldown;
    public double timeBetweenCharacters, timeBeforeMission;
    int i, j, bi;
    private bool header, description, objectives, textFinished;
    private string missionButtonText, missionButtonTextNew;

	// Use this for initialization
	void Start () {
        
        inbox = GameObject.FindGameObjectWithTag("Inbox");
        inbox.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();

        UI = GameObject.FindGameObjectWithTag("Mission 1");
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        Debug.Log(UI.name);

        i = 0;
        j = 0;
        bi = 0;

        // Later on fetch this from the database as a random of all quests!
        missions = new Mission[] {
            new Mission("Tutorial 1", 
                "You move with the A/D or left and right arrows. Please go up the stairs by moving over there and then go up by pressing W or up arrow.", 
                new Objective[] {
                    new Objective("Please go upstairs.", Actions.wentUpstairs)
                }),
            new Mission(
                "Tutorial 2", 
                "A packet just arrived at your doorstep, go and check your inbox! Pick it up by pressing E.", 
                new Objective[] { 
                    new Objective(
                        "Check your inbox",
                        Actions.getItemsInbox) 
                })
        };
        mission = missions[bi];
        Debug.Log(missions.Length);

        cooldown = timeBetweenCharacters;
        timer = cooldown;

        header = true;
        description = true;
        objectives = true;
        textFinished = false;
        missionButtonText = "Missions\n";
        missionButtonTextNew = "Missions\nNew!";
    }

    public void Reset()
    {
        if (bi != missions.Length)
            bi++;
        Debug.Log("Reset Mission Handler. bi = " + bi);

        cooldown = timeBetweenCharacters;
        if (bi == missions.Length) cooldown = timeBeforeMission;
        timer = cooldown;

        i = 0;
        j = 0;

        header = true;
        description = true;
        objectives = true;
        textFinished = false;

        if (bi < missions.Length)
        {
            mission = missions[bi];
            UI.transform.FindChild("Header").GetComponent<Text>().text = "";
            UI.transform.FindChild("Description").GetComponent<Text>().text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0) timer = 0;

        #region Print Text
        if (timer == 0 && !textFinished && bi < missions.Length)
        {
            timer = cooldown;
            i++;
            if (header) 
            {
                UI.transform.FindChild("Header").GetComponent<Text>().text += mission.Header[i - 1];
                if (i == mission.Header.Length)
                {
                    i = 0;
                    header = false;
                    Debug.Log(i);
                }
            }
            else if (description)
            {
                UI.transform.FindChild("Description").GetComponent<Text>().text += mission.MissionText[i - 1];
                if (i == mission.MissionText.Length)
                {
                    i = 0;
                    description = false;
                    UI.transform.FindChild("Description").GetComponent<Text>().text += "\n\nObjectives: ";
                    Debug.Log(mission.Objectives[0].Description);
                }
            }
            else if (objectives)
            {
                UI.transform.FindChild("Description").GetComponent<Text>().text += mission.Objectives[j].Description[i - 1];

                if (i == mission.Objectives[j].Description.Length)
                {
                    i = 0;
                    j++;

                    UI.transform.FindChild("Description").GetComponent<Text>().text += "\n";

                    if (j == mission.Objectives.Length)
                    {
                        objectives = false;
                    }
                }
            }
            if (!header && !description && !objectives) textFinished = true;
        }
        #endregion

        if (mission.Completed == false)
        {
            foreach (Objective o in mission.Objectives)
            {
                // This does only work with missions with 1 objective
                if (player.LatestAction == o.Action)    // Mission Completed
                {
                    UI.transform.FindChild("Header").GetComponent<Text>().text = "Mission Complete!";
                    UI.transform.FindChild("Description").GetComponent<Text>().text = "";
                    mission.Completed = true;
                    if (bi != missions.Length - 1)
                        missionButtonsText.GetComponent<Text>().text += "\nNew!";
                    else
                        Reset();        // Last time, increase to remove UI
                }
            }
        }

        if (bi == missions.Length && timer == 0)
        {
            UI.SetActive(false);
        }
    }

    public bool Inbox
    {
        set { inbox.SetActive(value);  }
        get { return inbox; }
    }
    public int BoolIndex
    {
        set { if (mission.Completed && bi < missions.Length) bi = value; }
        get { return bi; }
    }
    public bool MissionCompleted
    {
        get { return mission.Completed; }
    }
}
