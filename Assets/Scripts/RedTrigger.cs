using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTrigger : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform C;
    public Transform D;



    [SerializeField] private GameObject enemyP1; // link to the pefarb
    [SerializeField] private GameObject enemyP11; // link to the pefarb

    private GameObject enemy;
    private GameObject enemy2;
    
    public float speed=12.0f;
    public float direction = -1;
    bool  entered=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (D.transform.position.x > 23 && entered)
        {
            D.transform.Translate(0, 0, speed * direction * Time.deltaTime);
        }
        else
        {
            entered = false;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        entered = true;
        GetComponent<Renderer>().material.color = new Color(0.8f, 0,0);
        A.GetComponent<Renderer>().material.color = new Color(0.8f, 0, 0);
        B.GetComponent<Renderer>().material.color = new Color(0.8f, 0, 0);
        C.GetComponent<Renderer>().material.color = new Color(0.8f, 0, 0);




        //copy the perfap to the object
        enemy = Instantiate(enemyP1) as GameObject;
        enemy2 = Instantiate(enemyP11) as GameObject;

        enemy.transform.position = new Vector3(41,33.5f, 253);
        enemy2.transform.position = new Vector3(-27, 33.5f, 247);








    }

}
