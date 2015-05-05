using UnityEngine;
using System.Collections;

public class TestObjekt : MonoBehaviour {

    private Sprite start;
    public Sprite target;

    private int c = 0;
    private bool b = false;

    void Start()
    {
        start = GetComponent<SpriteRenderer>().sprite;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Show GUI");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Disable GUI");
    }

}
