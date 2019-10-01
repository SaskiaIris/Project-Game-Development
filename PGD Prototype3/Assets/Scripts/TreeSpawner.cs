using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject tree, treeContainer;

    [SerializeField]
    private float spawnRangeX = 20, spawnRangeZ = 20;

    [SerializeField]
    private int amountOfTrees = 100;

    private void Awake()
    {
        for(int i = 0; i < amountOfTrees; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));
            Quaternion spawnRotation = Quaternion.Euler(0, Random.Range(0, 360f), 0);
            Instantiate(tree, spawnPos, spawnRotation, treeContainer.transform);
        }
    }
}
