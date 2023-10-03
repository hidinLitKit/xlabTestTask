using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonEx
{
     public float timer;
     public Image activePanel;
     public TMP_Text textField;

    public ButtonEx(float timer, Image image, TMP_Text text)
    {
        this.timer = timer;
        activePanel = image;
        textField = text;
    }

    public void OnStart()
    {
        try
        {
            textField.text = "";
            activePanel.fillAmount = 0;
        }
        catch { Debug.Log("OnStart function error"); };
        
    }
}