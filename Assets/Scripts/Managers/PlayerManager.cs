using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour , MyGameManager
{
    public int lives { get; private set; }
    public bool key { get; private set; }
    public bool Tower1 { get;  set; }
    public bool Tower2 { get;  set; }



    public StatusManager status
    {
        get;
        private set;
    }

    public void Startup()
    {
        Debug.Log("start player manager");

        lives = 5;
        key = false;
        status = StatusManager.Started;
        Tower1 = false;
        Tower2 = false;
    }

    public void ChangeLives()
    {
        if (Managers.Inventory.equippedItem != "shield" && Managers.Inventory.GetItemCount(Managers.Inventory.equippedItem)>0 )
        {
            lives = lives - 1;
            if (lives == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }
        else
        {
           int count = Managers.Inventory.GetItemCount(Managers.Inventory.equippedItem);
            Managers.Inventory.consume(Managers.Inventory.equippedItem);

        }
    }
}


