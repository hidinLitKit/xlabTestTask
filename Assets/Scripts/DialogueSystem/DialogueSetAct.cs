using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSetAct : MonoBehaviour
{
    private GameObject cloud;
    private GameObject task3;
    private string requireName;
    public enum npcType
    {
        Farmer,
        Miner,
        SecondFarmer
    }
    public npcType chooseType;
    public GameObject oldDialogue;
    public GameObject newDialogue;
    public GameObject prop;
    private bool requir = false;
    void Start()
    {
        cloud = GameObject.Find("rain_cloud");
        task3 = GameObject.Find("Задание 3");
        requireName = "VillagerPickaxe";
    }
    void Update()
    {
        NpcType(chooseType);
    }

    public void NpcType(npcType op)
    {
        switch(op)
        {
            case npcType.Farmer:
            if (requir== false && cloud.GetComponent<RainController>().npcNum==3)
            {
                requir = true;
                DialogueSwitch();

            }
            break;
            case npcType.Miner:
            if(requir == false && task3.GetComponent<Spawner>().rockCount==3)
            {
                requir = true;
                DialogueSwitch();
            }

            break;
            case npcType.SecondFarmer:
            if(requir == false)
            {
                for(int i = 0; i < task3.GetComponent<ToolChange>().npcTools[0].transform.childCount; i++)
                {
                    Transform childTransform = task3.GetComponent<ToolChange>().npcTools[0].transform.GetChild(i);
                    if(childTransform.gameObject.activeSelf)
                    {
                        GameObject activeChild = childTransform.gameObject;
                        if (activeChild.name==requireName)
                        {
                            requir = true;
                            DialogueSwitch();
                        }
                        break;
                    }
                }
            }
            break;
        }
    }
    public void DialogueSwitch()
    {
        oldDialogue.SetActive(false);
        newDialogue.SetActive(true);
        prop.SetActive(true);
    }
    
}
