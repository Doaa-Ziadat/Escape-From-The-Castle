using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelativeRotation : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float rotSpeed = 15.0f;
    public float speed;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
           float hor= Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        if(hor!=0 || vert!=0)
        {
            movement.x = hor;
            movement.z = vert;
        }
        Quaternion temp = player.rotation;
        player.eulerAngles = new Vector3(0, player.eulerAngles.y, 0);
        movement = player.TransformDirection(movement);
        player.rotation = temp;
        // transform.rotation = Quaternion.LookRotation(movement);

        /*
        movement.x = hor * speed;
        movement.z = vert * speed;
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
        
        characterController.Move(movement);
        */

        Quaternion direction = Quaternion.LookRotation(movement);
        transform.rotation = Quaternion.Lerp(transform.rotation,  direction, rotSpeed * Time.deltaTime);

    }


}
