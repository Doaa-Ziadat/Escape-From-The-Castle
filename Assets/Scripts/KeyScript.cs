using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public float rad  = 0f; //radious- key distance to door 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     //   if(Input.GetButton("Fire3"))
        {
          //OverlapSphere  eturns an array of all objects that are within a given distance in specefic position 
            Collider[] hit = Physics.OverlapSphere(transform.position,rad);
            foreach ( Collider hitCollider in hit)
            {
                // use  SendMessage() is because we don’t know the exact type of the target object and that command works on all GameObjects
                // for this reason I used DontRequireReceiver so other objects can ignore it , 
                //add if statement if he has the key !!
                Vector3 vec = hitCollider.transform.position - transform.position;
                if(Vector3.Dot(transform.forward,vec)>0.8f)
                { // only if the player face the door , because of that I calculate the direstion using dot product.
                hitCollider.SendMessage("DoorIsOpen", SendMessageOptions.DontRequireReceiver);

                }


            }
        }
        
    }
}
