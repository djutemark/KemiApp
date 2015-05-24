using UnityEngine;
using System.Collections;
using Parse;

public class ParseTest : MonoBehaviour {

    public string username;

	// Use this for initialization
	void Start () {

	}

    public void Debugg()
    {
        Debug.Log(ParseUser.CurrentUser.Username);
    }
}
