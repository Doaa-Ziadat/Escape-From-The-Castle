using System.Collections;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyP; // link to the pefarb
    private GameObject enemy;
    int enemyTogether=2;
    int generate = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(enemyTogether > 0 )
        {
            //copy the perfap to the object
            enemy = Instantiate(enemyP) as GameObject;

            int x = Random.Range(-7, 9);
            // maybe later use variable
            int z = Random.Range(20,50);

            enemy.transform.position = new Vector3(x, 1, z);
          

           // enemy.transform.Rotate(0, angle, 0);
            enemyTogether--;
        }

        if (enemy == null && generate>0)
        {

            enemyTogether = 3;
            generate--;
        }


    }
}
