using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestr : MonoBehaviour
{
    public float destrTime = 1.5f;
    private void Start()
    {
        StartCoroutine(selfDestroy());
    }
    IEnumerator selfDestroy()
    {
        yield return new WaitForSeconds(destrTime);
        Destroy(this.gameObject);
    }

}
