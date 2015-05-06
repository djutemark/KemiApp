using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public float moveSpeed;
    public Sprite[] sprites;

    private Rigidbody2D rigidbody2D;
    private bool goingRight;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rbody;
    private bool stairs;
    private double timeBeforeUp; // Time before we can press up again
    private GameObject[] floors;
    private uint currentFloor;

    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rbody = GetComponent<Rigidbody2D>();
        goingRight = true;
        stairs = false;
        timeBeforeUp = 0;

        floors = GameObject.FindGameObjectsWithTag("Stair");
        currentFloor = 0;
    }

    void Movement()
    {
        #region Go left and right
        rbody.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, 0);
        
        if (Input.GetAxis("Horizontal") > 0) goingRight = true;
        if (Input.GetAxis("Horizontal") < 0) goingRight = false;

        // Flip player
        if (goingRight)
            spriteRenderer.sprite = sprites[0];
        else
            spriteRenderer.sprite = sprites[1];

        transform.rotation = new Quaternion(0, 0, 0, 0);
        #endregion

        #region Go up the stairs
        if (timeBeforeUp > 0) timeBeforeUp -= Time.deltaTime;
        else timeBeforeUp = 0;

        double button = Input.GetAxis("Vertical");

        if (button != 0 && timeBeforeUp == 0)
        {
            timeBeforeUp = .5;

            if (stairs)
            {
                if (button > 0)
                {
                    if (currentFloor == floors.Length - 1)
                    {
                        Debug.Log("Du är på den översta våningen!");
                    }
                    else
                    {
                        for (int j = 0; j < floors.Length; j++)
                        {
                            if (floors[j].GetComponent<Stairs>().floor == currentFloor + 1)
                            {
                                currentFloor++;
                                transform.position = floors[j].transform.GetChild(0).position;
                                Debug.Log("Nuvarande våning = " + floors[j].GetComponent<Stairs>().floor);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (currentFloor == 0)
                    {
                        Debug.Log("Du är på våningen längst ner!");
                    }
                    else
                    {
                        for (int j = 0; j < floors.Length; j++)
                        {
                            if (floors[j].GetComponent<Stairs>().floor == currentFloor - 1)
                            {
                                currentFloor--;
                                transform.position = floors[j].transform.GetChild(0).position;
                                break;
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public bool Stairs
    {
        set { stairs = value; }
        get { return stairs; }
    }

}
