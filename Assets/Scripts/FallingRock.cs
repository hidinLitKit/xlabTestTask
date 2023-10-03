using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour
{
    public GameObject rock;
    public GameObject spawnPoint;
    public int rockCount = 0;
    private bool CD = true;
    void Update()
    {
        if (CD && Input.GetKeyDown(KeyCode.X))
        {
            CreateObject();
            rockCount++;
        }
    }

    private void CreateObject()
    {
        Instantiate(rock, spawnPoint.transform.localPosition, spawnPoint.transform.localRotation);
        StartCoroutine(CoolDown());
    }
    IEnumerator CoolDown()
    {
        CD = !CD;
        yield return new WaitForSeconds(1f);
        CD = !CD;
    }
}
