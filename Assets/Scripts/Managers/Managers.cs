using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(InventoryManager))]

public class Managers : MonoBehaviour
{
    // static properties so now I can access managers in the code ( managers.InventoryManager/playerManager)
    public static PlayerManager Player { get; private set; }
    public static InventoryManager Inventory { get; private set; }

    private List<MyGameManager> startSeq;

    // initialization tasks that absolutely must run before any other code modules.

    void Awake()
    {
        Player = GetComponent<PlayerManager>();
        Inventory = GetComponent<InventoryManager>();

        startSeq = new List<MyGameManager>();
        startSeq.Add(Player);
        startSeq.Add(Inventory);

       //can run asynchronously, with other parts of the game proceeding too
        StartCoroutine(ManagersStartup());



    }

    private IEnumerator ManagersStartup()
    {
        foreach(MyGameManager manager in startSeq)
        {
            manager.Startup();
        }

        yield return null;

        int ModulesNumbers = startSeq.Count;
        int ReadyModules = 0;
        while(ReadyModules < ModulesNumbers)
        {
            int lastReady = ReadyModules;
            ReadyModules = 0;

            foreach(MyGameManager manager in startSeq)
            {
                if (manager.status == StatusManager.Started)
                    ReadyModules++;
            }

            if(ReadyModules>lastReady)
            
                Debug.Log("progress" + ReadyModules + "/" + ModulesNumbers);

            yield return null;
        }

        Debug.Log(" moudles start up complete");
    }
}
