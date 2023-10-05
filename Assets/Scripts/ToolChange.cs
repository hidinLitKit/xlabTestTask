using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolChange : MonoBehaviour
{
    public List<GameObject> npcTools;

    public void MakeChange()
    {
        foreach(GameObject gm in npcTools)
            {
                foreach(Transform ch in gm.transform)
                {
                    ch.gameObject.SetActive(false);
                }
                System.Random x = new System.Random();
                gm.transform.GetChild(x.Next(4)).transform.gameObject.SetActive(true);
            }
    }


}
