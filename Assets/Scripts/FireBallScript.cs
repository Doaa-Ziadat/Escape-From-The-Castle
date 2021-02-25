using System.Collections;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerReact player = other.GetComponent<PlayerReact>();
        if(player!=null)
        {
            Debug.Log("Player hit!");
            Destroy(this.gameObject);

            player.HurtPlayer(damage);
        }
        Destroy(this.gameObject);
    }
}
