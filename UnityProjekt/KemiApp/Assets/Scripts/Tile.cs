using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

    int i = 0;

    public Sprite bytTill;

    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sprite = bytTill;
        Debug.Log("Hello" + i);
        i++;
    }
}
