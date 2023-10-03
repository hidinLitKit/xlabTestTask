using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject titleMenu;
    [SerializeField] GameObject ButtonPanel;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject Marks;
    [SerializeField] GameObject MarkFinish;
    [SerializeField] GameObject cam;
    [SerializeField] float endPos;
    [SerializeField] float endRotation;
    [SerializeField] float speed;
    [SerializeField] AudioSource buttonAudio;
    [SerializeField] AudioSource gameOverAudio;
    [SerializeField] AudioSource winAudio;
    Vector3 defaultPosition;
    Vector3 defaultRotation;
    [SerializeField]GameObject controller;
    [SerializeField] GameObject WinMenu;
    [SerializeField] GameObject Progress;
    [SerializeField] GameObject time;


    public bool stop;
    Vector3 camPos;
    Quaternion camRot;

    private void Start()
    {
        stop = false;
        camPos = cam.transform.position;
        camRot = cam.transform.localRotation;
    }

    public void OnPlay()
    {
        stop = false;
        cam.transform.position = camPos;
        cam.transform.rotation = camRot;
        titleMenu?.SetActive(false);
        LeanTween.moveLocalY(cam, endPos, speed);
        LeanTween.rotateX(cam, endRotation, speed);

        ButtonPanel.SetActive(true);
        Marks?.SetActive(true);
        Progress?.SetActive(true);
        controller.GetComponent<tester>().StartGame();
        ClearMarks();
    }

    public void onRestart()
    {
        GameOver?.SetActive(false);
        controller.GetComponent<tester>().playable = true;

        //переместить камеру и начать все заново
        OnPlay();
    }

    public void OnGameOver()
    {
        if(stop)
        {
            return;
        }
        gameOverAudio?.Play();
        GameOver?.SetActive(true);
        ButtonPanel?.SetActive(true);
        controller.GetComponent<tester>().playable = false;
        TMP_Text timeText = time.GetComponent<TMP_Text>();
        float value = Progress.GetComponent<Slider>().value;
        int min = (int)(value / 60);
        int sec = (int)(value - min * 60);
        if(sec < 10)
            timeText.text = $"{min}:0{sec}";
        else
            timeText.text = $"{min}:{sec}";
        stop = true;
    }

    public void Win()
    {
        WinMenu?.SetActive(true);
        controller.GetComponent<tester>().playable = false;
        winAudio?.Play();
        Marks?.SetActive(false);
        stop = true;
    }

    public void BackToMenu()
    {
        titleMenu.SetActive(true);
        WinMenu?.SetActive(false);
        GameOver?.SetActive(false);
        Progress?.SetActive(false);
        Marks?.SetActive(false);
        ClearMarks();
    }

    public void PlayAudio()
    {
        buttonAudio?.Play();
    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void AddFinishMark()
    {
        if(Marks.transform.childCount < 3)
        {
            GameObject mark = Instantiate(MarkFinish);
            mark.transform.parent = Marks.transform;
            mark.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
        Check();
    }

    void Check()
    {
        if(Marks.transform.childCount == 3)
            OnGameOver();
    }

    void ClearMarks()
    {
       int c = Marks.transform.childCount;
       for(int i = 0; i<c; i++)
        {
            Destroy(Marks.transform.GetChild(i).gameObject);
        }
    }
}
