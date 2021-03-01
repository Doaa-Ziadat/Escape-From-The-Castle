using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemey2Script : MonoBehaviour
{
    private bool alive = true;

    void Start()
    {
        this.alive = true;

    }

    public void setAlive(bool alive)
    {

        this.alive = alive;
    }

    public bool getAlive()
    {

        return alive;
    }


    // Update is called once per frame
    void Update()
    {
    }

 
}