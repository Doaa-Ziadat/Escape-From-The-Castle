using System.Collections;
using UnityEngine;

public class TargetReact : MonoBehaviour
{

  
    public void HitReact()
    {
        EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
        if(enemyMovement!=null)
        {
            enemyMovement.setAlive(false);
        }
        StartCoroutine(Die());
    }

  private IEnumerator Die()
    {
        this.transform.Rotate(-75,0,0 );
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject); 
    }

}
