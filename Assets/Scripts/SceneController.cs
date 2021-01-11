using System.Collections;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyP; // link to the pefarb
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy==null)
        {
            //copy the perfap to the object
            enemy = Instantiate(enemyP) as GameObject;
            enemy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0,360);
            enemy.transform.Rotate(0, angle, 0);

        }
        
    }
}
