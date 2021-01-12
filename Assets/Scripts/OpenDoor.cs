using System.Collections;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Vector3 dis; // the amount the door moves when it is open ,
    private bool open;
    void Start()
    {
        open = false;
    }

    // Update is called once per frame
    public void UpdateDoor()
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
        
    }
}
