using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField] private GameObject fireBallP;
    private GameObject fireball;
    public int bulletTogether = 15;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Managers.Inventory.equippedItem == "Arrow")
        {
            if (bulletTogether > 0)
            {
                bulletTogether--;
                fireball = Instantiate(fireBallP) as GameObject;
                fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                //fireball.transform.position = transform.TransformPoint(Vector3.up * 3.2f);
                fireball.transform.rotation = transform.rotation;

            }

            if (fireball == null)
            {
                bulletTogether = 15;
            }
        }
    }
}
