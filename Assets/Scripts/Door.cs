using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Vector3 dis;
    bool opened;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Managers.Inventory.equippedItem == "key")
        {
            Vector3 pos = transform.position - dis;
            transform.position = pos;
            opened = true;
        }
    }
}
