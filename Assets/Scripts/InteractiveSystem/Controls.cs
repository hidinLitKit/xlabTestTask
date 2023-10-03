using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public GameObject controls;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)) controls.SetActive(!controls.activeSelf);
        
    }
}
