using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerObjects : MonoBehaviour
{
    [SerializeField]
    private Transform spawnerParent;
    [SerializeField]
    private GameObject spawnPrefab;
    [SerializeField]
    private int spawnCount = 0;

    [SerializeField]
    private float xLimit = 100;
    [SerializeField]
    private float zLimit = 100;
    [SerializeField]
    private int yPos = 1;
    [SerializeField]
    private float minDistance = .1f;

    private List<Vector3> usedPositions;
    

    [SerializeField]
    private GameObject[] spawnedGameObjects;

    // Start is called before the first frame update
    void Start()
    {
        spawnPrefabs();
    }

    //Generate Random Position and Spawn Prefabs
    public void spawnPrefabs()
    {
        usedPositions = new List<Vector3>();
        spawnedGameObjects = new GameObject[spawnCount];
        int i = 0;
        while (i < spawnCount)
        {
            float x = Random.Range(0.0f, xLimit);
            float z = Random.Range(0.0f, zLimit);
            Vector3 newPos = new Vector3(x, yPos, z);
            if (IsValidPosition(newPos))
            {
                usedPositions.Add(newPos);
                spawnedGameObjects[i] = Instantiate(spawnPrefab, newPos, Quaternion.identity, spawnerParent);

                i++;
            }
        }

    }

    //Validate Position of Prefabs Object so that the objects do not overlap
    private bool IsValidPosition(Vector3 pos)
    {
        foreach (Vector3 usedPos in usedPositions)
        {
            if (Vector3.Distance(pos, usedPos) < minDistance)
            {
                return false;
            }
        }
        return true;
    }
}
