using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGeneratorScript : MonoBehaviour
{
    public GameObject brick;
    GameObject newSpawnedBrick;
    Vector3 spawnLocation;

    public GameObject winnerCanvas;

    public Vector3 DistanceX;
    public Vector3 DistanceY;


    public bool Debugging = false;

    #region BrickColors

    // Sets color for corresponding rows
    public static Color firstRows;
    public static Color middleRows;
    public static Color lastRows;

    // Sets color for corresponding rows for debugging
    public Color debugFirstRows;
    public Color debugMiddleRows;
    public Color debugLastRows;

    #endregion
    
    public static int limit = 33;
    public int DebugBricks = 33;
    public static int totalBricksLeft;
    int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        MainCode();
    }

    // Update is called once per frame
    void Update()
    {
        if (totalBricksLeft == 0 && level == 1)
        {
            spawnLocation = transform.position;
            DistanceY = new Vector3(0, transform.position.y + 0.5f, 0);
            level++;
            MainCode();
        }else if (level == 2 && totalBricksLeft == 0)
        {
            winnerCanvas.SetActive(true);
            Time.timeScale = 0;
        }

    }

    GameObject CreateBrick(Vector3 spawn)
    {
        newSpawnedBrick = Instantiate(brick, spawn, Quaternion.identity);
        newSpawnedBrick.transform.parent = transform;

        return newSpawnedBrick;
    }

    void MainCode()
    {
        if (Debugging == true)
        {
            limit = DebugBricks;
            firstRows = debugFirstRows;
            middleRows = debugMiddleRows;
            lastRows = debugLastRows;
        }

        totalBricksLeft = limit + 1;

        newSpawnedBrick = CreateBrick(transform.position);
        spawnLocation = newSpawnedBrick.transform.position + DistanceX;

        for (int i = 0; i < limit; i++)
        {
            newSpawnedBrick = CreateBrick(spawnLocation);

            // Checking if newly spawned brick is outside game
            if (spawnLocation.x < 8)
            {
                spawnLocation = newSpawnedBrick.transform.position + DistanceX;
            }
            else
            {
                spawnLocation = transform.position + DistanceY;
                DistanceY = DistanceY + new Vector3(0, 0.5f);
            }
        }
    }
}
