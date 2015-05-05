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

    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rbody = GetComponent<Rigidbody2D>();
        goingRight = true;
        stairs = false;
        timeBeforeUp = 0;
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

        if (Input.GetButton("Vertical") && timeBeforeUp == 0)
        {
            timeBeforeUp = .5;

            if (stairs)
                Debug.Log("Gå upp!");
            else
                Debug.Log("Ingen trappa i närheten!");
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
