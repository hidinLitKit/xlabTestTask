using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ShowHint : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject hint;

    public void OnPointerDown(PointerEventData eventData)
    {
        if(GetComponent<Button>().interactable == false)
        {
            LeanTween.move(hint.GetComponent<RectTransform>(), new Vector3(166, -30, 0), 0.5f);
            Invoke("Move", 3f);
        }
    }

    void Move()
    {
        LeanTween.move(hint.GetComponent<RectTransform>(), new Vector3(166, 50, 0), 2f);
    }


}
