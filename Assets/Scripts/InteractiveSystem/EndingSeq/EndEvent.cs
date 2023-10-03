using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class EndEvent : MonoBehaviour
{
    public GameObject[] cond = new GameObject[3];
    public GameObject[] condItems = new GameObject[3];
    private bool isHappened = false; 
    public GameObject Cats;
    public AudioSource funkyMusic;
    public AudioSource peacefulMusic;
    public GameObject roomTp;
    public PostProcessVolume postpr;
    void Update()
    {
        if(isHappened!=true)
        {
            int k = 0;
            for(int i =0;i<cond.Length;i++)
            {
                if(cond[i].transform.childCount!=0 && cond[i].transform.GetChild(0).gameObject.name == condItems[i].name) k++;
            }
            if(k==3)
            {
                Debug.Log("Hurray");
                isHappened = true;
                StartCoroutine(party());
            } 
        }
    }
    IEnumerator party()
    {
        Cats.SetActive(true);
        funkyMusic.Play();
        yield return new WaitForSeconds(30f);
        funkyMusic.Stop();
        GameObject.Find("Ambience").GetComponent<AudioSource>().Stop();
        peacefulMusic.Play();
        GameObject.FindGameObjectWithTag("Player").transform.position = roomTp.transform.position;
        postpr.profile.GetSetting<Bloom>().intensity.Override(8f); // ошибка 
        
        


    }
}
