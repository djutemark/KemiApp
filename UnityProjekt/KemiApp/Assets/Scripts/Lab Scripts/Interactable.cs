﻿using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

    public Actions action;

    private HelperHandler helperHandler;

    private int c = 0;
    private bool b = false;

    void Start()
    {
        helperHandler = GameObject.FindGameObjectWithTag("Handlers").transform.FindChild("Helper Handler").GetComponent<HelperHandler>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            helperHandler.HelpSign = true;
            helperHandler.ActionToPlayer = action;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            helperHandler.HelpSign = false;
            helperHandler.ActionToPlayer = Actions.nothing;
        }
    }
}