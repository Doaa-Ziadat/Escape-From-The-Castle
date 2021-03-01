using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float speed = 1.5f;
    private float yRoation;

    private float xRoation;
    public GameObject WeaponCamera = null;

    private Vector3 offest;
   // public Transform target, obstruction;
    float zoomSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
       // obstruction = target;
        yRoation = transform.eulerAngles.y;
        offest = player.position - transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    private void LateUpdate()
    {
        // trying to fix when obstacle in front of the camera 
        /*
        RaycastHit hit;
        if(Physics.Raycast(transform.position,target.position-transform.position,out hit,4.5f))
        {
            if(hit.collider.gameObject.tag!= "playerThird")
            {
                obstruction = hit.transform;
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
            }
            else
            {
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                if(Vector3.Distance(transform.position,target.position)<4.5f)
                { 
                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime); 
                }
            }
        }

        */
       /* float horizontal = Input.GetAxis("Horizontal");
        if(horizontal !=0)  // using keyboard 
        {
            yRoation += horizontal * speed;
       }
        
        else */ 
       // or using the mouse
        {
            yRoation += Input.GetAxis("Mouse X") * speed * 2;
            if (WeaponCamera != null)
            {
                if (WeaponCamera.active == true)
                {
                    xRoation += -Input.GetAxis("Mouse Y") * speed * 2;
                }
                else
                    xRoation = 0;

            }
            else
            {
                xRoation = 0;
            }
        }

        // convert  the rotaion to quaternion 
        Quaternion rotation = Quaternion.Euler(xRoation, yRoation, 0);
        // Multiplying a position vector by a quaternion  
        //results in a position that’s shifted over according to that rotation
       transform.position = player.position - (rotation * offest);
        
        transform.LookAt(player);
    }
}
