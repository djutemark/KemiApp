using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {
    /* Anteckningar
     * Roboto
     * oPen Sans
     * 
     * FLAT Design
     */
    public GameObject blockVolumeSW, blockVolumeSE, tile, wallLeft, wallRight;
    public int rows, columns;
    public Sprite[] tileSprites, wallSprites;
    
    private int currentTile, prevTile;
    private GameObject[] tiles, walls;
    private bool refresh;

	// Use this for initialization
	void Start () {
        refresh = true; // Refresh = true forces us to instantiate tiles the first frame. Because of this refresh variable we can refresh the size of the floor from another script
        currentTile = 0; // Tile to start with, get this from database

        // Area, rader * columns
        for (int i = 0; i < (rows * columns); i++)
        {
            Instantiate(tile, new Vector3(i / columns, 0, i % columns), transform.rotation);
        }
        tiles = GameObject.FindGameObjectsWithTag("Tile"); // Hitta alla tiles => golvet


        // Halva omkretsen ska vara vägg, 2 i höjd
        for (int i = 0; i < rows; i++)
        {
            Instantiate(wallLeft, new Vector3(i, 1, columns - 0.5f), new Quaternion());
        }
        for (int i = 0; i < columns; i++)
        {
            Instantiate(wallRight, new Vector3(rows - 0.5f, 1, i), Quaternion.Euler(0, 90, 0));
        }
        walls = GameObject.FindGameObjectsWithTag("Wall"); // Hitta alla wall's => väggen

        // Sätt upp collision så vi inte kan gå utanför rummet
        // Kontrollera om vi har ett jämnt anatl rader och därefter justera x-axeln
        float x, z;

        blockVolumeSE.transform.localScale = new Vector3(rows, 2, 1);
        if (rows % 2 == 0) x = rows / 2 - 0.5f;
        else x = rows / 2;
        Instantiate(blockVolumeSE, new Vector3(x, 1, -1), new Quaternion()); // SouthEast
        Instantiate(blockVolumeSE, new Vector3(x, 1, columns), new Quaternion()); // NorthWest

        blockVolumeSW.transform.localScale = new Vector3(columns, 2, 1);
        if (columns % 2 == 0) z = columns / 2 - 0.5f;
        else z = columns / 2;
        Instantiate(blockVolumeSW, new Vector3(rows, 1, z), Quaternion.Euler(0, 90, 0)); // NorthEast
        Instantiate(blockVolumeSW, new Vector3(-1, 1, z), Quaternion.Euler(0, 90, 0)); // SouthhWest
	}

	void Update () {
        if (refresh) // Byt sprite på golvet då vi trycker refresh till sprite:n på plats currentTile i listan tileSprites
        {
            foreach (GameObject t in tiles)
            {
                t.GetComponent<SpriteRenderer>().sprite = tileSprites[currentTile];
                
            }
            refresh = false; // Kör loop:en endast en gång
        }
	}

    // Test GUI, debug och testing
    void OnGUI()
    {
        /*
        GUI.BeginGroup(new Rect(Screen.width / 2 - 400, Screen.height / 2 - 300, 800, 600));
        GUI.Box(new Rect(0, 0, 800, 600), "Hello World in groups!");
        GUI.EndGroup();
        */
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

    // Ej klar metod
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
