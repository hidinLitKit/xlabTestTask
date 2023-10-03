using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class LetterFade : MonoBehaviour
{
    public Image img;
    private bool isFaded = false;
    void Awake()
    {
        img = img.GetComponent<Image>();
    }
    void Update()
    {
        if(gameObject.GetComponent<Dialogue>().IsDialogueAct == true && isFaded==false)
        {
            img.DOFade(1f,1f);
            isFaded = true;
        }
        if(gameObject.GetComponent<Dialogue>().IsDialogueAct == false && isFaded == true)
        {
            img.DOFade(0f,1f);
            isFaded = false;
        }
    }
}
