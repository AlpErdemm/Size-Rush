﻿using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private DateTime _sessionStartTime;
    private DateTime _sessionEndTime;

    public bool obstaclesActive;

    private void Start()
    {
        obstaclesActive = false;
        _sessionStartTime = DateTime.Now;
        Debug.Log("Game session start at: " + _sessionStartTime);
    }

    private void OnApplicationQuit()
    {
        _sessionEndTime = DateTime.Now;
        TimeSpan timeDifference = _sessionEndTime.Subtract(_sessionStartTime);

        Debug.Log("Game session ended at: " + DateTime.Now);
        Debug.Log("Game session lasted for: " + timeDifference);
    }
}
