using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillsBeh : Interactable
{
    public GameObject pill;
    public enum pillType
    {
        red,
        blue
    }
    public pillType whatPill;
    public override string GetDescription() {
        return "выбрать";
    }

    public override void Interact() {
        switch(whatPill)
        {
            case pillType.red:
            Application.Quit();
            break;

            case pillType.blue:
            pill.SetActive(false);
            break;

        }
    
    }
}
