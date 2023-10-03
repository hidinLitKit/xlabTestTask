using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AttachItem : Interactable
{
    [HideInInspector] Transform slot;
    [HideInInspector] public GameObject menuInventory;
    public Transform AttachSlot;
    [HideInInspector] public Transform item;
    private bool isAttached = false;
    void Awake()
    {
        menuInventory = GameObject.Find("Inventory");
        slot = GameObject.Find("Hand").GetComponent<Transform>();
        AttachSlot = AttachSlot.transform;
    }
    void Update()
    {
        if (AttachSlot.childCount == 0)
        {
            isAttached = false;
        }
    }
    public override string GetDescription() {
        if (isAttached == false) return "Вставить";
        return "...";
    }

    public override void Interact() {
        if(AttachSlot.childCount==0) DoAttachItem();
        // if (item.transform.parent & item.transform.parent.name == "Hand")
        // {
        //     DoAttachItem();
        //     if(slot.transform.Find(nameItem).gameObject.activeSelf)
        //     {
        //         DoAttachItem();
        //     }  
        // }
 
    }
    private void DoAttachItem(){
        item = slot.GetChild(DetectChildInt());
        menuInventory.GetComponent<InventoryCreate>().MakeChange(DetectChildInt());
        item.SetParent(AttachSlot);
        item.localPosition = Vector3.zero;
        item.localEulerAngles = Vector3.zero;
        isAttached = !isAttached;
        item.gameObject.GetComponent<Collider>().enabled = true;
    }
    public int DetectChildInt()
    {
        int k = 0;
        while(k<slot.childCount)
        {
            Transform child = slot.GetChild(k);
            if (child.gameObject.activeInHierarchy) return k;
            k++;
        }
        return k;
    }
}
