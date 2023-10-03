using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject catDiag;
    public GameObject pills;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(catDiag.activeSelf==false)
        {
            pills.SetActive(true);
            GetComponent<Ending>().enabled=false;
        }
        

    }
}
