using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Floor : MonoBehaviour {
    /* Anteckningar
     * Roboto
     * oPen Sans
     * 
     * FLAT Design
     */
    public GameObject tile;
    public int rows, columns;
    public Sprite[] sprites;
    
    private int currentTile, prevTile;
    private GameObject[] tiles;
    private bool refresh;

	// Use this for initialization
	void Start () {
        refresh = true; // Refresh = true forces us to instantiate tiles the first frame. Because of this refresh variable we can refresh the size of the floor from another script
        currentTile = 1; // Tile to start with, get this from database

        for (int i = 0; i < (rows * columns); i++)
        {
            Instantiate(tile, new Vector3(i / columns, 0, i % columns), transform.rotation);
        }
        tiles = GameObject.FindGameObjectsWithTag("Tile");
        Debug.Log(tiles.Length);
	}

	void Update () {
        if (refresh)
        {
            foreach (GameObject t in tiles)
            {
                t.GetComponent<SpriteRenderer>().sprite = sprites[currentTile];
            }
            
            refresh = false;
        }
	}

    // Test GUI
    void OnGUI()
    {
        GUI.TextArea(new Rect(10, 10, 100, 20), "Current Tile: " + currentTile);

        if (GUI.Button(new Rect(10, (0 * 25) + 50, 100, 20), "Grey"))
            currentTile = 0;

        if (GUI.Button(new Rect(10, (1 * 25) + 50, 100, 20), "Black & White"))
            currentTile = 1;

        if (GUI.Button(new Rect(10, (2 * 25) + 50, 100, 20), "Green & White"))
            currentTile = 2;

        if (GUI.Button(new Rect(10, (4 * 25) + 50, 100, 20), "Refresh"))
            refresh = true;
    }

    void AddTiles()
    {
        foreach (GameObject t in tiles)
        {
            Destroy(t);
        }

        for (int i = 0; i < (rows * columns); i++)
        {
            Instantiate(tile, new Vector3(i / columns, 0, i % columns), transform.rotation);
        }
        tiles = GameObject.FindGameObjectsWithTag("Tile");
    }

    #region Setters and Getters
    
    public bool Refresh
    {
        get { return refresh; }
        set { refresh = value; }
    }
    
    #endregion
}
