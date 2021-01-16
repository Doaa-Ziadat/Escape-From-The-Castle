using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MyGameManager 
{
    // tell us if the moudle completed initilization 
    StatusManager status {
        get; 
    }

    // used to initilaize the manager 
    void Startup();


}
