using System.Collections;
using UnityEngine;

public class TargetReact : MonoBehaviour
{
    int flag = 0;

    public void HitReact()
    {
        Debug.Log("died..");

        EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
        if(enemyMovement!=null)
        {
            enemyMovement.setAlive(false);
        }
        if(this.transform.parent != null)
        {

            enemyMovement =  this.GetComponentInParent<EnemyMovement>();
            enemyMovement.setAlive(false);
            flag = 1;

        }
        StartCoroutine(Die());
    }

  private IEnumerator Die()
    {
        if(flag==1)
        {
            this.transform.parent.Rotate(-75, 0, 0);
            yield return new WaitForSeconds(1.5f);
            Destroy(this.transform.parent.gameObject);
        }
        this.transform.Rotate(-75,0,0 );
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject); 
    }

}
