using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionHandler : MonoBehaviour {

    private GameObject inbox, UI;
    private Mission mission;
    private Character player;

    private double timer, cooldown;
    public double timeBetweenCharacters, timeBeforeMission;
    int i, j, bi;
    private bool header, description, objectives, textFinished;
    private bool[] missions;

	// Use this for initialization
	void Start () {
        inbox = GameObject.FindGameObjectWithTag("Inbox");
        inbox.SetActive(false);

        // Later on fetch this from the database as a random of all quests!
        mission = new Mission("Learning the game", "We will eventually teach you how to play this boring game!", new Objective[] { new Objective("Please go upstairs.", Actions.wentUpstairs)});

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();

        UI = GameObject.FindGameObjectWithTag("Mission 1");
        Debug.Log(UI.name);

        i = 0;
        j = 0;
        bi = 0;

        cooldown = timeBetweenCharacters;
        timer = cooldown;

        header = true;
        description = true;
        objectives = true;
        textFinished = false;

        missions = new bool[] { false, false };
    }

    void Reset()
    {
        cooldown = timeBetweenCharacters;
        timer = cooldown;

        i = 0;
        j = 0;

        header = true;
        description = true;
        objectives = true;
        textFinished = false;

        UI.transform.FindChild("Header").GetComponent<Text>().text = "";
        UI.transform.FindChild("Description").GetComponent<Text>().text = "";
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0) timer = 0;

        #region Print Text
        if (timer == 0 && !textFinished)
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

        if (!mission.Completed)
        {
            foreach (Objective o in mission.Objectives)
            {
                if (player.LatestAction == o.Action)
                {
                    UI.transform.FindChild("Header").GetComponent<Text>().text = "Mission Complete!";
                    UI.transform.FindChild("Description").GetComponent<Text>().text = "";
                    mission.Completed = true;
                    timer = timeBeforeMission;
                    bi++;
                }
            }
        }
        else if (timer == 0 && bi < missions.Length)
        {
            mission = new Mission("You got mail!", "A packet just arrived at your doorstep, go and check your inbox!", new Objective[] { new Objective("Check your inbox", Actions.getItemsInbox) });
            cooldown = timeBetweenCharacters;
            Reset();
        }
    }

    public bool Inbox
    {
        set { inbox.SetActive(value);  }
        get { return inbox; }
    }
}
