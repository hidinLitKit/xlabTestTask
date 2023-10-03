using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    Camera cam;
    Slider slider;
    public bool finished = false;
    public MenuController menuController;
    [Header("Speed of filling")]
    public float maxSpeed;
    private float _speed;
    public float Speed { 
        get {
            return _speed;
        } 
        set {
            _speed = value; 
        } 
    }

    void Start()
    {
        cam = Camera.main;
        slider = GetComponent<Slider>();

        Speed = maxSpeed;
    }

    void Update()
    {
        //поворот слайдера
        transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position);

        //Работа слайдера
        slider.value += Speed*Time.deltaTime;
        if(slider.value == slider.maxValue && !finished)
        {
            finished = true;
            menuController.AddFinishMark();
        }
    }
}
