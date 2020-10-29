using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [Header("Private Values")]
    public GameObject Floor;
    public GameObject Wall;

    [Header("Private Values")]
    [SerializeField] private int Rows;
    [SerializeField] private int Cols;
    [SerializeField] private float TileSize;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {

        for (int Row = 0; Row < Rows; Row++)
        {
            for (int Col = 0; Col < Cols; Col++)
            {
                GameObject tile = Instantiate(Floor, transform);
                float PosX = Row * TileSize;
                float PosZ = Col * -TileSize;

                tile.transform.position = new Vector3(PosX, transform.position.y, PosZ);
            }
        }

        for (int Row = 0; Row < Rows; Row++)
        {
            
            GameObject tile = Instantiate(Wall, transform);
            float PosX = Row * TileSize;
            tile.transform.position = new Vector3(PosX, transform.position.y + 1, transform.position.z);
            
        }

        for (int Row = 0; Row < Rows; Row++)
        {

            GameObject tile = Instantiate(Wall, transform);
            float PosX = Row * TileSize;
            tile.transform.position = new Vector3(PosX, transform.position.y + 1, transform.position.z - Cols + 1);

        }

        for (int Row = 0; Row < Rows; Row++)
        {

            GameObject tile = Instantiate(Wall, transform);
            float PosZ = (Row) * -TileSize;
            tile.transform.position = new Vector3(transform.position.x, transform.position.y + 1, PosZ);

        }

        for (int Row = 0; Row < Rows; Row++)
        {

            GameObject tile = Instantiate(Wall, transform);
            float PosZ = (Row) * -TileSize;
            tile.transform.position = new Vector3(transform.position.x + Cols - 1, transform.position.y + 1, PosZ);

        }
    }
}
