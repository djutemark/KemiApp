using UnityEngine;
using System.Collections;

public class Inbox : MonoBehaviour {

    private Item item;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Item Item
    {
        set { item = value; }
        get { return item; }
    }
}
