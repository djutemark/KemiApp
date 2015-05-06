using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITest : MonoBehaviour {

    // Get text from database
    string text = "A description of what should be done. Example: Do this ASAP!!";
    double timer;
    public double cooldown;
    int i = 0;

	// Use this for initialization
	void Start () {
        cooldown = 0.2;
        timer = cooldown;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= cooldown;

        if (timer < 0) timer = 0;

        if (timer == 0 && i < text.Length)
        {
            timer = cooldown;
            GetComponent<Text>().text += text[i];
            i++;
        }
	}
}
