using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float moveSpeed;

    private Vector3 right, forward;

	// Use this for initialization
	void Start () {
        right = new Vector3(0.9f, 0, -0.4f);
        forward = new Vector3(0.4f, 0, 0.9f);
        Debug.Log(transform.right);
        Debug.Log(transform.forward);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.D))
            transform.Translate(right * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(-right * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
            transform.Translate(forward * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(-forward * moveSpeed * Time.deltaTime);
        
	}
}
