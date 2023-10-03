using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCreate : MonoBehaviour
{
    public GameObject[] slots = new GameObject[8];
    public GameObject originPoint;
    public GameObject slot;
    public GameObject garbage;
    void Start()
    {
        slots[0] = slot;
        CreateInventory();
    }
    public void CreateInventory()
    {
        for(int i = -45, k = 1;i<=225;i+=45,k++)
        {
            GameObject slotN = Instantiate(slot, originPoint.transform.position + new Vector3(Mathf.Cos(i*(Mathf.PI/180)),0,Mathf.Sin(i*(Mathf.PI/180))), 
            originPoint.transform.localRotation);
            slotN.transform.parent = originPoint.transform;
            slotN.name = "slot"+k;
            slots[k] = slotN;
            
        }
    }
    public void MakeChange(int k)
    {
        Transform dispose = slots[k].transform.GetChild(0);
        dispose.parent = garbage.transform;
        dispose.position = garbage.transform.position;
        for(int i = k+1;i<slots.Length;i++)
        {
            if(slots[i].transform.childCount==0) break;
            Transform temp = slots[i].transform.GetChild(0);
            temp.parent = slots[i-1].transform;
            temp.transform.position = slots[i-1].transform.position;
        }


    }
}
