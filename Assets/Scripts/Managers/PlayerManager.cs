using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour , MyGameManager
{
    public int lives { get; private set; }
    public bool key { get; private set; }

    public StatusManager status
    {
        get;
        private set;
    }

    public void Startup()
    {
        Debug.Log("start player manager");

        lives = 3;
        key = false;
        status = StatusManager.Started;
    }

    public void ChangeLives()
    {
        lives = lives - 1;

    }
}


