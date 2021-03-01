using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball2Script : MonoBehaviour
{

    public float speed = 10.0f;
    public float obstacleDistance = 5.0f;
    private bool alive;

    public int damage = 1;

    float rotationSpeed = 0.9f;// betwen 0-1
    GameObject targetObject = null;
    Vector3 Movement;
    bool twiceflag = true;
    float minY = 25.2f;


    void Start()
    {
        this.alive = true;

        //target to rotate towards
        targetObject = GameObject.FindGameObjectWithTag("TargetObject") as GameObject;


    }

    public void setAlive(bool alive)
    {

        this.alive = alive;
    }


    // Update is called once per frame
    void Update()
    {

        if (this.alive)
        {
          
            if (targetObject == null)
            {
                return;
            }
            // get position of target object
            Vector3 targetPosition = targetObject.transform.position;
            targetPosition.y = targetPosition.y + 2.5f;



            // calculate rotation to 
             Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);

            // rotation at z  and x axis is zero
            // targetRotation.z = 0;
            //targetRotation.x = 0;

            // Apply rotation
             transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);



            Vector3 direction = targetPosition - transform.position;
            // apply movement toward the player 
            direction.Normalize();
            Movement = direction;
            //  transform.position = transform.position + direction * 4.0f * Time.deltaTime;

            if(transform.position.y<minY)
            {
                Destroy(this.gameObject, 0.5f);
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = targetObject.transform.position;
        float distance = Vector3.Distance(targetPosition, transform.position);
    
            if (transform.position != targetObject.transform.position)
                transform.position = transform.position + Movement * 10.0f * Time.deltaTime;
  
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerReact player = other.GetComponent<PlayerReact>();
        if (player != null && twiceflag==true)
        {
            Debug.Log("Player hit!");
            Destroy(this.gameObject);

            player.HurtPlayer(damage);
            twiceflag = !twiceflag;
        }
        Destroy(this.gameObject);
    }
   
}





