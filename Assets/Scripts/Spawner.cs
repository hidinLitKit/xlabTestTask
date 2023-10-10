using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnObject;
    public GameObject spawnPoint;
    public int rockCount = 0;
    private bool CD = false;

    public void Spawn()
    {
            var prefab = getRandomPrefab();
            if (prefab == null)
            {
                Debug.Log("No prefab");
                return;
            }
            Instantiate(prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
            rockCount++;
        
    }
    private GameObject getRandomPrefab()
    {
        if (spawnObject.Length == 0)
        {
            Debug.Log("Spawn objects are empty");
            return null;
        }
        int index = Random.Range(0, spawnObject.Length);
        var prefab = spawnObject[index];
        return prefab;
        
    }
}
