using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemCanBePicked : Interactable
{
    GameObject Inventory;
    Transform slot;
    [HideInInspector] public GameObject item;
    public string descr;
    
    
    void Awake()
    {
        item = gameObject;
        slot = GameObject.Find("Hand").GetComponent<Transform>();
        Inventory = GameObject.Find("Inventory");
    }
    public override string GetDescription() {
        return descr;
    }

    public override void Interact() {
        PickItem();
    
    }
    private void PickItem(){
        item.transform.SetParent(slot);
        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;
        item.GetComponent<Collider>().enabled = false;
        item.gameObject.SetActive(false);
        item.gameObject.layer = 7;

        foreach(GameObject it in Inventory.GetComponent<InventoryCreate>().slots)
        {
            if(it.transform.childCount==0)
            {
                GameObject newItem = Instantiate(item, it.transform.position, it.transform.rotation);
                newItem.transform.parent = it.transform;
                newItem.SetActive(true);

                break;
            }
        }
        
    }
}
