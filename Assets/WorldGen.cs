using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    public GameObject tilePrefab;
    private GameObject worldContainer;
    public int worldSizeX = 20;
    public int worldSizeY = 20;

    private static List<Tile> selectedTiles = new List<Tile>();

    // Start is called before the first frame update
    void Start()
    {
        MakeWorld();
    }

    void MakeWorld()
    {
        worldContainer = new GameObject();

        for(int x = 0; x < worldSizeX; ++x)
        {
            for(int y = 0; y < worldSizeY; ++y)
            {
                MakeTile(x,y);
            }
        }
    }

    private void MakeTile(float x, float y)
    {
        var newTile = GameObject.Instantiate(tilePrefab);

        newTile.transform.position = new Vector3(x*1.025f,0,y*1.025f);
        newTile.transform.parent = worldContainer.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void SelectTile(Tile tile)
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            removeTileFromSelection(tile);
        }
        else
        {
            if(!Input.GetKeyDown(KeyCode.LeftShift))
                ClearSelection();
                
            addTileToSelection(tile);
        }
    }

    public static void ClearSelection()
    {
        Debug.Log("cleared selection");
        selectedTiles.ForEach(t => t.Deselect());
        selectedTiles.Clear();
    }

    private static void addTileToSelection(Tile tile)
    {
        Debug.Log("added tile to selection");
        if(!tile) throw new ArgumentException("Expected one tile in call to \"AddTileToSelection\", got null");

        if(!selectedTiles.Contains(tile)) selectedTiles.Add(tile);
    }

    private static void removeTileFromSelection(Tile tile)
    {
        Debug.Log("removed tile from selection");
        if(!tile) throw new ArgumentException("Expected one tile in call to \"RemoveTileFromSelection\", got null");

        if(selectedTiles.Contains(tile)) selectedTiles.Remove(tile);
    }
}
