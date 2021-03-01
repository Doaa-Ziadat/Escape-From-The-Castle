using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooters : MonoBehaviour
{

    public float speed = 3.0f;
    public float obstacleDistance = 5.0f;
    private bool alive;
    public GameObject front;


    float rotationSpeed = 0.9f;// betwen 0-1
    GameObject targetObject = null;
    Vector3 Movement;

    int offestTarget;

    [SerializeField] private GameObject fireBallP;
    private GameObject fireball;
    private Quaternion targetRotation;
    private Vector3 direction;


    // Start is called before the first frame update
    void Start()
    {

        this.alive = true;

        //target to rotate towards
        targetObject = GameObject.FindGameObjectWithTag("TargetObject") as GameObject;
        offestTarget = Random.Range(10, 3);

    }


    public void setAlive(bool alive)
    {

        this.alive = alive;
    }

    void Update()
    {

        if (this.alive)
        {
            //transform.Translate(0, 0, speed * Time.deltaTime);

            // add the code to mov  chase the player and rotate towards him 

            if (targetObject == null)
            {
                return;
            }
            // get position of target object
            Vector3 targetPosition = targetObject.transform.position;

            //temp 
            targetPosition = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z);


            // targetPosition = targetPosition + new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));


            // calculate rotation to 
            if (fireball == null)
            {
                targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
                direction = targetPosition - transform.position;

            }

            else
            {
                targetRotation = Quaternion.LookRotation(targetPosition - fireball.transform.position);
                direction = targetPosition - fireball.transform.position;


            }

            // rotation at z  and x axis is zero
            targetRotation.z = 0;
            targetRotation.x = 0;

            // Apply rotation
          //  transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);



            // apply movement toward the player 
            direction.Normalize();
            Movement = direction;
            //  transform.position = transform.position + direction * 4.0f * Time.deltaTime;


            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 10f, out hit))
            {

                GameObject hitObject = hit.transform.gameObject;
                PlayerReact player = hitObject.GetComponent<PlayerReact>();
                if (player)
                {
                    // Debug.Log("near the player ");
                    if (fireball == null)
                    {
                        Physics.SphereCast(ray, 0.05f, out hit);

                        hitObject = hit.transform.gameObject;
                        player = hitObject.GetComponent<PlayerReact>();
                        // if (!player)
                        {

                            fireball = Instantiate(fireBallP) as GameObject;
                            fireball.transform.position = front.transform.TransformPoint(Vector3.forward * 1.5f);
                             fireball.transform.position = front.transform.TransformPoint(Vector3.up * 3.2f);
                            fireball.transform.rotation = front.transform.rotation;

                            Vector3 targetPosition2 = targetObject.transform.position;
                            float distance = Vector3.Distance(targetPosition2, fireball.transform.position);


                            // if (fireball.transform.position != targetObject.transform.position)
                            fireball.transform.position = fireball.transform.position + Movement * 1.0f * Time.deltaTime;

                        }

                    }
                }

                /*  else
                   {

                       if (hit.distance < obstacleDistance)
                       {
                           float alpha = Random.Range(-110, 110);
                           transform.Rotate(0, alpha, 0);
                       }
                   }
                */

            }
        }
    }


    private void FixedUpdate()
    {
        if (fireball != null)
        {
            Vector3 targetPosition = targetObject.transform.position;
            float distance = Vector3.Distance(targetPosition, fireball.transform.position);


            // if (fireball.transform.position != targetObject.transform.position)
             fireball. transform.position = fireball.transform.position + Movement * 1.0f * Time.deltaTime;
        }
    }
   
}





