using System.Collections;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Vector3 dis; // the amount the door moves when it is open ,
    private bool open = false;
    void Start()
    {
    }

    // Update is called once per frame
    public void DoorIsOpen()
    {
        if(open)
        {
            Vector3 pos = transform.position - dis;
            transform.position = pos;

        }
        else
        {
            Vector3 pos = transform.position +dis;

            transform.position = pos;

        }

        open = !open;

        GetComponent<Renderer>().material.color = new Color(0.4f, 1.0f, 0.4f);
        
    }
}
