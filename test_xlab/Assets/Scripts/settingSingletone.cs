using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingSingletone 
{
    private static settingSingletone instance;
    private Settings settings;


    private int _readyWorkerCount;
    public int ReadyWorkerCount
    {
        get { return _readyWorkerCount; }
        set { 
            if(_readyWorkerCount == settings.CountWorkerToEnd)
            //Конец игры
            {

            }
            else
                _readyWorkerCount = value; 
        }
    }

    private settingSingletone(Settings settings)
    {
        this.settings = settings;
    }

    public static settingSingletone GetInstance(Settings settings = null)
    {
        if (instance == null)
        {
            if (settings != null)
            {
                instance = new settingSingletone(settings);
                instance.ReadyWorkerCount = 0;
            }               
            else throw new Exception("Settings should be initialized");
        }
        return instance;
    }

    public float GetStoneTimer()
    {
        return settings.stoneEnableButtonTimer;
    }
    public float GetRainTimer()
    {
        return settings.rainEnableButtonTimer;
    }
    public float GetToolTimer()
    {
        return settings.toolEnableButtonTimer;
    }
    public float GetOutlineWidth()
    { 
        return settings.outlineWidth;
    }
}
