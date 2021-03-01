using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockTrigger : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform C;
    public Transform D;
    public float speed = 6.0f;
    public float direction = -1;

    private bool open = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (D.transform.position.x < 46.9f && open)
        {
            D.transform.Translate(0, 0, speed * direction * Time.deltaTime);
          
        }
        else
        {
            open = false;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TargetObject"))
        {
            open = true;
            transform.Translate(1, 0, 0);
            GetComponent<Renderer>().material.color = new Color(0, 0.7f, 0);
            A.GetComponent<Renderer>().material.color = new Color(0, 0.7f, 0);
            B.GetComponent<Renderer>().material.color = new Color(0, 0.7f, 0);
            C.GetComponent<Renderer>().material.color = new Color(0, 0.7f, 0);
        }
    }
}
