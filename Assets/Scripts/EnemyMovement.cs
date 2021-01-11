using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleDistance = 5.0f;
    private bool alive;

    [SerializeField] private GameObject fireBallP;
    private GameObject fireball;
    void Start()
    {
        this.alive = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (this.alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {

                GameObject hitObject = hit.transform.gameObject;
                PlayerReact player = hitObject.GetComponent<PlayerReact>();
                if (player)
                {
                    if (fireball == null)
                    {
                        fireball = Instantiate(fireBallP) as GameObject;
                        fireball.transform.position= transform.TransformPoint(Vector3.forward * 1.5f);
                        fireball.transform.rotation = transform.rotation;


                    }
                }

                else
                {

                    if (hit.distance < obstacleDistance)
                    {
                        float alpha = Random.Range(-110, 110);
                        transform.Rotate(0, alpha, 0);
                    }
                }
            }
        }
    }

    public void setAlive (bool alive)
    {

        this.alive = alive;
    }


}
