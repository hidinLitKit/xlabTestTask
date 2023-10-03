using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    
    public GameObject HandInventory;

    public GameObject Player;
    public Camera inventoryCamera;
    private bool isOpen = false;
    void Start()
    {
        inventoryCamera.enabled = false;
        HandInventory.GetComponent<SwitchItems>().enabled = isOpen;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)) 
        {
            isOpen = !isOpen;
            HandInventory.GetComponent<SwitchItems>().enabled = isOpen;
            if(isOpen == true)
            {
                Player.GetComponent<FirstPersonController>().playerCanMove = false;
                Player.GetComponentInChildren<Camera>().enabled = false;
                HandInventory.GetComponent<SwitchItems>().InventoryUI.SetActive(true);
                inventoryCamera.enabled = true;
                
            }
            else
            {
                Player.GetComponent<FirstPersonController>().playerCanMove = true;
                Player.GetComponentInChildren<Camera>().enabled = true;
                HandInventory.GetComponent<SwitchItems>().InventoryUI.SetActive(false);
                inventoryCamera.enabled = false;
            }
        }

    }
}
