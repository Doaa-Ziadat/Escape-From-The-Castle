using System.Collections;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyP; // link to the pefarb
    private GameObject enemy;
    int enemyTogether=3;
    int generate = 3;
    int z1=20, z2=30;
    bool firstgen = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // if((Managers.Inventory).GetItemCount("key")==1)
       if((firstgen &&Managers.Inventory.equippedItem==("key")) || (!firstgen && ((Managers.Inventory).GetItemCount("key") == 1)))
            {
            firstgen = false;
            if ((enemyTogether > 0))
            {
                //copy the perfap to the object
                enemy = Instantiate(enemyP) as GameObject;

                int x = Random.Range(-7, 19);
                //use variables
                int z = Random.Range(z1, z2);
                z1 += 5;
                z2 += 5;

                enemy.transform.position = new Vector3(x, 1, z);


                // enemy.transform.Rotate(0, angle, 0);
                enemyTogether--;


            }


            if (enemy == null && generate > 0)
            {

                enemyTogether = 4;
                generate--;
            }
        }

    


    }
}
