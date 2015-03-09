using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Floor : MonoBehaviour {
    
    public GameObject tile;
    public int rows, columns;
    public Sprite[] sprites;
    
    private int currentTile, prevTile;
    private List<GameObject> tiles;
    private bool refresh;

	// Use this for initialization
	void Start () {
        refresh = true; // Refresh = true forces us to instantiate tiles the first frame. Because of this refresh variable we can refresh the size of the floor from another script
        currentTile = 1; // Tile to start with, get this from database

        tiles = new List<GameObject>();
        for (int i = 0; i < (rows * columns); i++)
        {
            tiles.Add(tile);
            Debug.Log("Hello");
        }
	}
	
	
	void Update () {
        if (refresh)
        {
            GameObject[] existentTiles = GameObject.FindGameObjectsWithTag("Tile");
            Debug.Log(existentTiles.Length);

            foreach (GameObject tile in existentTiles)
            {
                Destroy(tile);
            }

            int i = 0;
            foreach (GameObject t in tiles) // The usage of foreach-loops enables us to dynamically change the size of the floor
            {
                t.GetComponent<SpriteRenderer>().sprite = sprites[currentTile - 1];
                Instantiate(t, new Vector3(i / columns, 0, i % columns), transform.rotation);
                i++;
            }
            refresh = false;
        }
	}

    void OnGUI()
    {
        GUI.TextArea(new Rect(10, 10, 100, 20), "Current Tile: " + currentTile);

        if (GUI.Button(new Rect(10, (0 * 25) + 50, 100, 20), "Grey"))
            currentTile = 1;

        if (GUI.Button(new Rect(10, (1 * 25) + 50, 100, 20), "Black & White"))
            currentTile = 2;

        if (GUI.Button(new Rect(10, (2 * 25) + 50, 100, 20), "Green & White"))
            currentTile = 3;

        if (GUI.Button(new Rect(10, (4 * 25) + 50, 100, 20), "Refresh"))
            refresh = true;
    }

    #region Setters and Getters
    
    public bool Refresh
    {
        get { return refresh; }
        set { refresh = value; }
    }
    
    #endregion
}
