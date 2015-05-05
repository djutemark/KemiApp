using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

    public float distance;

    private GameObject player;
    
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player.name);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -distance), new Vector3(player.transform.position.x, player.transform.position.y, -distance), 0.2f);
	}
}
