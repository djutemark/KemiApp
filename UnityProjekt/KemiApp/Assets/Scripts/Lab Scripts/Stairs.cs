using UnityEngine;
using System.Collections;

public class Stairs : MonoBehaviour {

    public uint floor;
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Character>().Stairs = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            other.GetComponent<Character>().Stairs = false;
    }

}
