using UnityEngine;
using System.Collections;

public class HelperHandler : MonoBehaviour {

    private bool helpSign, last;
    private GameObject player;

    private Actions actionToPlayer;

    private double time, cooldown;

	// Use this for initialization
	void Start () {
        helpSign = false;
        last = false;
        player = GameObject.FindGameObjectWithTag("Player");

        cooldown = 0.3;
        time = cooldown;
	}
	
	// Update is called once per frame
	void Update () {
        if (helpSign != last)
        {
            last = helpSign;
            player.transform.FindChild("Helper").GetComponent<SpriteRenderer>().enabled = helpSign;
        }

        time -= Time.deltaTime;
        if (time < 0) time = 0;
        if (Input.GetKey(KeyCode.E) && time == 0 && helpSign)
        {
            Debug.Log("Open something");
        }else if (Input.GetKey(KeyCode.E)) Debug.Log("Do nothing.");
	}

    public bool HelpSign 
    {
        set { helpSign = value; }
        get { return helpSign; }
    }
    public Actions ActionToPlayer
    {
        set { player.GetComponent<Character>().LatestAction = value; }
    }
}
