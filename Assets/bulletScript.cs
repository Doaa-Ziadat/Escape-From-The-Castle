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

                Debug.Log("target hit!");
                Destroy(this.gameObject);
               target.HitReact();

        }

        if (other.CompareTag("enemey1") || other.CompareTag("enemey11"))
        {
            if(other.CompareTag("enemey1"))
            {
                Managers.Player.Tower1 = false;
            }
            else
            {
                Managers.Player.Tower2 = false;

            }

            Debug.Log("Targeeeet2 hit");
            Target2React target2 = other.GetComponent<Target2React>();
            if(target2==null)
            {
                target2 = this.GetComponentInParent<Target2React>();
            }
            if (target2 != null)
            {
                Destroy(this.gameObject);
                target2.HitReact();
            }

        }
        Destroy(this.gameObject);
        }
    
}
