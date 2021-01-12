using System.Collections;
using UnityEngine;

public class FirePath : MonoBehaviour
{
    public float speed = 3.0f;
    public float zMax = 16.0f;
    public float zMin = -16.0f;

    private int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, direction * speed * Time.deltaTime);

        if(transform.position.z > zMax || transform.position.z <zMin)
        {
            direction = -direction;
            transform.Translate(0, 0, direction * speed * Time.deltaTime);

        }


    }
}
