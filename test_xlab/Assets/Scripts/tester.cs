using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.IO;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class tester : MonoBehaviour
{
    Vector3 pos = new Vector3(59.7700005f, 49.6899986f, -28.4699993f);
    [SerializeField] Transform stone;
    Vector3 dir;
    Vector3 start = new Vector3(68.4000015f, 51f, 19.3099995f);
    [SerializeField] Transform[] endpoints;
    [SerializeField] Transform cloudObj;
    public int currentHumanIndex = 0;
    State currentState = State.idle;
    float distationToStop = 0.1f;
    public float speed = 10f;

    public Mesh[] nextTool;
    Mesh previousTool;
    GameObject[] tools;

    [SerializeField] Settings settings;
    [SerializeField] Camera mainCamera;
    //не должны быть публичными
    [SerializeField] GameObject currentHuman;
    [SerializeField] GameObject prevHuman;
    [SerializeField] GameObject Progress;
    [SerializeField] GameObject Menu;
    MenuController menu;
    [SerializeField] float speedOfProgress;
    Slider progress;
    Vector3 posHuman;
    GameObject rainPartical;


    //StateGame game;
    bool isRunning;
    bool humanIsSelected;
    [SerializeField]GameObject cloudButton;
    [SerializeField] GameObject AudioRain;
    AudioSource rainAudio;

    public GameObject currentHumanToRain;

    public List<Slider> sliders = new List<Slider>();

    public bool playable;

    private void Awake()
    {
        var settingInstance = settingSingletone.GetInstance(settings);
        isRunning = true;
    }

    void Start()
    {
        tools = GameObject.FindGameObjectsWithTag("tool");

        dir = new Vector3(0, -1, 0);
        cloudObj.transform.position = start;
        rainPartical = cloudObj.transform.GetChild(0).gameObject;
        humanIsSelected = false;
        rainAudio = AudioRain.GetComponent<AudioSource>();

        foreach(var transform in endpoints)
        {
            sliders.Add(transform.GetComponentInChildren<Slider>());
        }
        foreach (var slider in sliders)
        {
            slider.gameObject.SetActive(false);
            slider.gameObject.GetComponent<ProgressBarController>().menuController = Menu.GetComponent<MenuController>();
        }

        progress = Progress.GetComponentInChildren<Slider>();
        menu = Menu.GetComponent<MenuController>();

    }

    void Update()
    {
        
        if(playable)
        {
            progress.value += speedOfProgress*Time.deltaTime;
            if(progress.value >= progress.maxValue)
            {
                menu.Win();
            }
            if (currentState == State.move)
            {
                rainAudio.Stop();
                //posHuman = endpoints[currentHumanIndex].transform.position;

                if (Vector3.Distance(cloudObj.transform.position, new Vector3(posHuman.x, cloudObj.transform.position.y, posHuman.z)) <= distationToStop)
                {
                    currentState = State.idle;
                    rainAudio.Play(1);
                    //idti rain
                    rainPartical.SetActive(true);
                    GameObject canvas = currentHumanToRain.transform.parent.GetChild(3).gameObject;
                    ProgressBarController bar = canvas.GetComponentInChildren<ProgressBarController>();
                    bar.Speed = bar.maxSpeed / 2;
                    Debug.Log(bar.Speed);
                    currentHumanToRain.transform.parent.GetComponent<Animator>().SetBool("stop", true);
                }
                else
                {
                    Vector3 direction = (new Vector3(posHuman.x, cloudObj.position.y, posHuman.z) - cloudObj.position).normalized;

                    cloudObj.transform.position += direction * Time.deltaTime * speed;
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 200))
                {
                    var outline = hit.collider.gameObject.GetComponent<Outline>();
                    if (outline != null)
                    {
                        currentHuman = hit.collider.gameObject;
                        if (prevHuman != null)
                            prevHuman.GetComponent<Outline>().OutlineWidth = 0;
                        outline.OutlineWidth = settingSingletone.GetInstance().GetOutlineWidth();
                        prevHuman = currentHuman;
                        if (!humanIsSelected)
                        {
                            cloudButton.GetComponent<Button>().interactable = true;
                            humanIsSelected = true;
                        }

                    }
                }
            }
        }
        
    }
    enum State
    {
        move,
        idle
    }

    public void CloudButtonOn()
    {
        //if (currentState == State.idle)
        //{
        //    if (currentHumanIndex + 1 == endpoints.Length)
        //        currentHumanIndex = 0;
        //    else currentHumanIndex++;
        //    currentState = State.move;
        //}
        if(currentHumanToRain != null)
        {
            GameObject canvas = currentHumanToRain.transform.parent.GetChild(3).gameObject;
            ProgressBarController bar = canvas.GetComponentInChildren<ProgressBarController>();
            bar.Speed = bar.maxSpeed;
            Debug.Log(bar.Speed);
            currentHumanToRain.transform.parent.GetComponent<Animator>().SetBool("stop", false);
        }
        if (currentState == State.idle)
        {
            currentHumanToRain = currentHuman;
            posHuman = currentHuman.transform.position;
            currentState = State.move;
            rainPartical.SetActive(false);
        }
    }
    public void InstantiateStone()
    {
        Instantiate(stone, pos, Quaternion.identity);
        Invoke("StoneHarm", 8f);
    }

    public void ChangeTool()
    {
        foreach (var tool in tools)
        {
            Mesh ToolToChange = nextTool[UnityEngine.Random.Range(0, nextTool.Length - 1)];
            tool.GetComponent<MeshFilter>().mesh = ToolToChange;
        }
        foreach(var slider in sliders)
        {
            slider.GetComponent<ProgressBarController>().Speed -= 1;
        }
        Invoke("AdaptTool", 3f);
    }

    public void StartGame()
    {
        playable = true;
        foreach (var slider in sliders)
        {
            slider.value = slider.minValue;
            slider.maxValue = 65f;
            slider.gameObject.SetActive(true);
            slider.GetComponent<ProgressBarController>().finished = false;
        }
        progress.value = progress.minValue;
        cloudObj.transform.position = start;
        rainAudio.Stop();
        rainPartical.SetActive(false);
    }

    void StoneHarm()
    {
        ProgressBarController bar = sliders[1].GetComponent<ProgressBarController>();
        bar.Speed = 0;
        endpoints[1].GetComponent<Animator>().SetBool("stop", true);
        StartCoroutine(RestoreDamage(endpoints[1].gameObject, 4f));

    }

    IEnumerator RestoreDamage(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        ProgressBarController bar = obj.GetComponentInChildren<ProgressBarController>();
        bar.Speed = bar.maxSpeed;
        obj.GetComponent<Animator>().SetBool("stop", false);
    }

    void AdaptTool()
    {
        foreach (var slider in sliders)
        {
            slider.GetComponent<ProgressBarController>().Speed += 1;
        }
    }
}
