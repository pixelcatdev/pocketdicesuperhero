using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CityTileProps : MonoBehaviour
{
    public enum TileType { Residential, Commercial, Industrial, Special }
    public TileType tileType;

    public string tileName;
    public int tileHp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void GenTile()
    {
        //Randomise the sprite on spawn
    }
}
