using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float max;
    public float min;
    public float  direction = 1;
    public float speed = 2.0f;
    public float offest = 1;
    public float current;
    // Start is called before the first frame update
    void Start()
    {
        if(direction==1)
        current = transform.position.x + offest;
       else
            current = transform.position.x - offest;
    }



    
    void Update()
    {
        transform.Translate(speed * direction * Time.deltaTime, 0, 0);
        checkDirection();
    }

    public void checkDirection()
    {
      /*  if (transform.position.x >= max)
        {
            direction = -1;
        }
        else if (transform.position.x <= min)
        {
            direction = 1;
        }
      */
      if(transform.position.x >=current && direction==1)
        {
            direction = -1;
            current = transform.position.x - offest;


        }
        else if (transform.position.x < current && direction==-1)
        {
            direction = 1;
            current = transform.position.x + offest;


        }
    }
}