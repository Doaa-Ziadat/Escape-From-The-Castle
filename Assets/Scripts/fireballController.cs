using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballController : MonoBehaviour
{
    // enemey p here is the fireball!
    [SerializeField] private GameObject enemyP; 
    [SerializeField] private GameObject enemy1; // the first
    [SerializeField] private GameObject enemy11; // the second 

    private GameObject enemy;
    public GameObject player;
    private int flag;
    int enemyTogether = 3;
    public int x;
    public int y;
    public int z;
    // Start is called before the first frame update
    void Start()
    {
        flag = Random.Range(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.z>202.0f && ( Managers.Player.Tower1 == true || Managers.Player.Tower2 == true))
        {
            if ((enemyTogether > 0) && enemy==null)
            {
                //copy the perfap to the object
                enemy = Instantiate(enemyP) as GameObject;

                if (flag == 1)
                {
                    x = -26;
                    z = 246;
                    y = 36;
                }
                else 
                {
                    x = 39;
                    y = 36;
                    z = 253;
                }

                enemy.transform.position = new Vector3(x, y, z);

                if (Managers.Player.Tower1 == true && Managers.Player.Tower2 == true)
                {
                    flag = Random.Range(0, 1);
                }
                else
                {
                    if (Managers.Player.Tower1 == true)
                    {
                        flag = 1;
                    }
                    else
                    {
                        flag = 0;
                    }
                }

              //  flag = !flag;
                // enemy.transform.Rotate(0, angle, 0);
                enemyTogether--;

            }


            if (enemy == null )
            {

                enemyTogether = 4;
            }


        }




    }
}


