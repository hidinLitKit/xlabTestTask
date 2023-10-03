using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject audioManager;
    AudioSource audioSource;
    TMP_Text text;
    [SerializeField] float speed;
    float defaultfontSize;

    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.value(gameObject, a => text.fontSize = a, defaultfontSize, defaultfontSize + 10, speed).setEase(LeanTweenType.easeInOutQuart);
        audioSource.Play();
    }


    void Start()
    {
        text = GetComponent<TMP_Text>();

        audioSource = audioManager.GetComponent<AudioSource>();
        defaultfontSize = text.fontSize;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.value(gameObject, a => text.fontSize = a, defaultfontSize + 10, defaultfontSize, speed).setEase(LeanTweenType.easeInOutSine); ;
    }

}
