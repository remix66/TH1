using UnityEngine;
using System.Collections;
using DG.Tweening;
public class SingleSpike : MonoBehaviour {

    [Header("Scripts")]
    public EnemyDetector enemyDetector;
    public BoxCollider2D spikeCol;
    private bool isAttacking;

    // Use this for initialization
    void Start () {

        isAttacking = false;
	
	}

	void Update ()
    {


    }

    public void Attack(GameObject enemy)
    {
        if (enemyDetector.targetFound)
        {
            if (enemyDetector.closestEnemy != null)
            {
                if (!isAttacking)
                {
                    isAttacking = true;

                    //Make the spike face the enemy
                    Vector3 vectorToTarget = enemy.transform.position - transform.position;
                    float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90f;

                    Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                    transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 100);

                    
                    spikeCol.enabled = true;
                    transform.DOScaleY(.5f, .2f).SetEase(Ease.OutQuint);
                    transform.DOScaleY(.0f, .1f).SetDelay(.2f).SetEase(Ease.InQuint).OnComplete(AttackDone);
                }
            }
        } 
    }

    public void Attack2(GameObject enemy)
    {
        if (enemyDetector.targetFound)
        {
            if (enemyDetector.closestEnemy != null)
            {
                if (!isAttacking)
                {
                    isAttacking = true;

                    //Make the spike face the enemy
                    Vector3 vectorToTarget = enemy.transform.position - transform.position;
                    float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90f;

                    Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                    transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 100);


                    spikeCol.enabled = true;
                    transform.DOScaleY(.5f, .2f).SetEase(Ease.OutQuint);
                    transform.DOScaleY(.0f, .1f).SetDelay(.2f).SetEase(Ease.InQuint).OnComplete(AttackDone);
                }
            }
        }
    }

    private void AttackDone()
    {
        isAttacking = false;
        spikeCol.enabled = false;
        
    }

}
