using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float max;
    public float min;
    public float  direction = 1;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

    }



    
    void Update()
    {
        transform.Translate(speed * direction * Time.deltaTime, 0, 0);
        checkDirection();
    }

    public void checkDirection()
    {
        if (transform.position.x >= max)
        {
            direction = -1;
        }
        else if (transform.position.x <= min)
        {
            direction = 1;
        }
    }
}