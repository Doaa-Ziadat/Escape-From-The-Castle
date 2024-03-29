﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(MazeConstructor))]               

public class GameController : MonoBehaviour
{
    [SerializeField] private FpsMovement player;
    [SerializeField] private Text timeLabel;
    [SerializeField] private Text scoreLabel;
    [SerializeField] private Text newmazelabel;


    private MazeConstructor generator;

    private DateTime startTime;
    private int timeLimit;
    private int reduceLimitBy;

    private int score;
    private bool goalReached;


    void Start()
    {
        generator = GetComponent<MazeConstructor>();
        //generator.GenerateNewMaze(13, 15);
        StartNewGame();


    }

    private void StartNewGame()
    {
        timeLimit = 60;
        reduceLimitBy = 5;
        startTime = DateTime.Now;

        score = 0;
        scoreLabel.text = score.ToString();
        newmazelabel.text = " ";

        StartNewMaze();
    }

    private void StartNewMaze()
    {
        //13,15
        generator.GenerateNewMaze(13, 15, OnStartTrigger, OnGoalTrigger);

        float x = generator.startCol * generator.hallWidth;
        float y = 1;
        float z = generator.startRow * generator.hallWidth;
        player.transform.position = new Vector3(x, y, z);

        goalReached = false;
        player.enabled = true;

        // restart timer
        timeLimit -= reduceLimitBy;
        startTime = DateTime.Now;
    }

    //
    void Update()
    {
        if (!player.enabled)
        {
            return;
        }

        int timeUsed = (int)(DateTime.Now - startTime).TotalSeconds;
        int timeLeft = timeLimit - timeUsed;

        if (timeLeft > 0)
        {
            timeLabel.text = timeLeft.ToString();
        }
        else
        {
            timeLabel.text = "TIME UP!";
            newmazelabel.text="THE cASTLE MAZE HAS CHANGED!";
            player.enabled = false;
            Managers.Player.ChangeLives();
            Invoke("StartNewGame", 4);
        }
    }

    private void OnGoalTrigger(GameObject trigger, GameObject other)
    {
        Debug.Log("Goal!");
        goalReached = true;

        score += 1;
        scoreLabel.text = score.ToString();

        Destroy(trigger);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    private void OnStartTrigger(GameObject trigger, GameObject other)
    {
      /*  if (goalReached)
        {
            Debug.Log("Finish!");

            player.enabled = false;

            Invoke("StartNewMaze", 4);
        }
      */
    }
}
