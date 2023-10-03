using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    float timer;
    ButtonEx currentButton;
    Button button;
    public buttonType type;

    public enum buttonType
    {
        rain, 
        stone,
        tool
    }

    void Start()
    {
        var instance = settingSingletone.GetInstance();
        Image img = gameObject.transform.GetChild(0).GetComponent<Image>();
        TMP_Text text = gameObject.GetComponentInChildren<TMP_Text>();
        float timerB = 0;
        switch (type)
        {
            case buttonType.rain:
                timerB = instance.GetRainTimer();
                break;
            case buttonType.stone:
                timerB = instance.GetStoneTimer();
                break;
            case buttonType.tool:
                timerB = instance.GetToolTimer();
                break;
        }


        currentButton = new ButtonEx(timerB, img, text);
        currentButton.OnStart();
        timer = 0;
        button = GetComponent<Button>();

    }

    void Update()
    {
        if(timer > 0)
        {
            if (timer - Time.deltaTime < 0) { EndTimer(); }
            else
            {
                timer -= Time.deltaTime;
                UpdateTimer(timer);
            }
        }
    }

    public void StartTimer()
    {
        timer = currentButton.timer;
        currentButton.textField.text = timer.ToString();
        currentButton.activePanel.fillAmount = 1;
        button.interactable = false;
    }

    void UpdateTimer(float time)
    {

        if(timer > 1)
            currentButton.textField.text = timer.ToString("#.#");
        else currentButton.textField.text = timer.ToString("0.#");
        currentButton.activePanel.fillAmount = 1/currentButton.timer * time;
    }

    void EndTimer()
    {
        currentButton.textField.text = "";
        currentButton.activePanel.fillAmount = 0;
        timer = 0;
        button.interactable = true;
    }

}
