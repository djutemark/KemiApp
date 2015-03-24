using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
    public float moveSpeed;

    private Vector3 moveDirection;
    private CharacterController cc;

	// Use this for initialization
	void Start () 
    {
        cc = GetComponent<CharacterController>();
        moveDirection = Vector3.zero;
	}

    void Movement() 
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed / 1000;
        cc.Move(moveDirection);
    }

	// Update is called once per frame
	void Update () 
    {
        Movement();
        Debug.Log(cc.velocity);
	}
}
