using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
  public float speed = 10.0f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // TargetReact target = other.GetComponent<TargetReact>();
        if (other.CompareTag("enemey"))
        {
            TargetReact target = other.GetComponent<TargetReact>();

            if (target != null)
            {
                Debug.Log("target hit!");
                Destroy(this.gameObject);
               target.HitReact();

            }
        }
            Destroy(this.gameObject);
        }
    
}
