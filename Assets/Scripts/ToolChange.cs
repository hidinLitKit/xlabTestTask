using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolChange : MonoBehaviour
{
    public List<GameObject> npcTools;
    private List<int> itemsOrig = new List<int>(){3,3,1,2,0};
    void Start()
    {
        MakeChange(itemsOrig);
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)) MakeChange();
    }
    void MakeChange()
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
    void MakeChange(List<int>itemsOrig)
    {
        int k = 0;
        foreach(GameObject gm in npcTools)
        {
            foreach(Transform ch in gm.transform)
            {
                ch.gameObject.SetActive(false);
            }
            gm.transform.GetChild(itemsOrig[k]).transform.gameObject.SetActive(true);
            k++;
        }
        
    }

}
