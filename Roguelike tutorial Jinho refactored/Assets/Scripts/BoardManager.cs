using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {

    [Serializable]
    public class Count
    {
        public int minimum;
        public int maximum;

        public Count (int min, int max)
        {
            minimum = min;
            maximum = max;
        }
    }

    public int columns = 8;
    public int rows = 8;
    public Count wallCount = new Count(5, 9);
    public Count foodCount = new Count(1, 5);

    // GameObjects
    public GameObject exit;
    public GameObject[] floorTiles;
    public GameObject[] outerWallTiles;
    public GameObject[] wallTiles;    
    public GameObject[] foodTiles;
    public GameObject[] enemyTiles;

    private Transform boardHolder;
    private List<Vector3> availablePositions = new List<Vector3>();

    void InitializeList()
    {
        availablePositions.Clear();

        for (int x = 1; x < columns - 1; x++)
            for (int y = 1; y < rows - 1; y++)
                availablePositions.Add(new Vector3(x, y, 0f));
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        for (int x = -1; x < columns + 1; x++)
            for (int y = -1; y < columns + 1; y++)
            {
                GameObject toInstantiate;


                if (x == -1 || x == columns || y == -1 || y == rows)
                    toInstantiate = outerWallTiles[Random.Range(0, outerWallTiles.Length)];
                else
                    toInstantiate = floorTiles[Random.Range(0, floorTiles.Length)];

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(boardHolder);
            }
    }

    Vector3 RandomPosition()
    {
        int randomIndex = Random.Range(0, availablePositions.Count);
        Vector3 randomPosition = availablePositions[randomIndex];
        availablePositions.RemoveAt(randomIndex);
        return randomPosition;
    }

    void LayoutObejctAtRandom(GameObject[] tileArray, int minimum, int maximum)
    {
        int objectCount = Random.Range(minimum, maximum + 1);

        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = RandomPosition();
            GameObject tileChoice = tileArray[Random.Range(0, tileArray.Length)];
            Instantiate(tileChoice, randomPosition, Quaternion.identity);
        }
    }

    public void SetupScene(int level)
    {
        InitializeList();
        // create floors and outer walls
        BoardSetup();
        // create walls
        LayoutObejctAtRandom(wallTiles, wallCount.minimum, wallCount.maximum);
        // create foods
        LayoutObejctAtRandom(foodTiles, foodCount.minimum, foodCount.maximum);
        // create enemies
        int enemyCount = (int)Mathf.Log(level, 2f);
        LayoutObejctAtRandom(enemyTiles, enemyCount, enemyCount);
        // create exit
        Instantiate(exit, new Vector3(columns - 1, rows - 1, 0f), Quaternion.identity);
    }
}
