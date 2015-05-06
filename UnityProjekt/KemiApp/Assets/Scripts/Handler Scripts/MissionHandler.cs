using UnityEngine;
using System.Collections;

public class MissionHandler : MonoBehaviour {

    private GameObject inbox;
    private Mission[] missions;

	// Use this for initialization
	void Start () {
        inbox = GameObject.FindGameObjectWithTag("Inbox");
        inbox.SetActive(false);

        //Mission m = new Mission("A sudden quest!", "I need you to create a new substance!", MissionObjectives.make);
        
        missions = new Mission[3] 
        { 
            new Mission("A mission header!", "You must construct additional pylons!", new Objective[1] 
                { 
                    new Objective(new string[1] {"Construct 1 pylon."}, new bool[1] { false }) 
                }),
            new Mission(),
            new Mission() 
        };

	}
	
	// Update is called once per frame
	//void Update () {}     // Will later on fetch missiondata from the database
}
