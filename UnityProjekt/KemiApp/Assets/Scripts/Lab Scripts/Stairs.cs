using UnityEngine;
using System.Collections;

public class Stairs : MonoBehaviour {

    public uint floor;
    private HelperHandler helperHandler;

    void Start()
    {
        helperHandler = GameObject.FindGameObjectWithTag("Handlers").transform.FindChild("Helper Handler").GetComponent<HelperHandler>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Character>().Stairs = true;
            helperHandler.HelpSign = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Character>().Stairs = false;
            helperHandler.HelpSign = false;
        }
    }

}
