using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyDetector : MonoBehaviour {

    private Transform player;
    public GameObject closestEnemy;
    public bool targetFound;
    public List<GameObject> enemiesClose = new List<GameObject>();
    public SpriteRenderer detectionCircle;

    void Start ()
    {
        player = transform.root;
        Debug.Log(player);
        targetFound = false;
        detectionCircle.color = new Color(1f, 1f, 1f, .3f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (enemiesClose.Count > 0)
        {
            findClosestEnemy();
            detectionCircle.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            detectionCircle.color = new Color(1f, 1f, 1f, .3f);
        }

    }

   void OnTriggerEnter2D(Collider2D other)
   {

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            
            targetFound = true;
            enemiesClose.Add(other.gameObject);

        }
   }
    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            if (closestEnemy != null) { closestEnemy = null; }
            
            targetFound = false;
            enemiesClose.Remove(other.gameObject);
        }
    }

    private void findClosestEnemy()
    {

        List<GameObject> enemiesInRange = new List<GameObject>();
        
        for (int i = enemiesClose.Count - 1; i >= 0; i--)
        {
            if (enemiesClose[i] == null)
            {
                enemiesClose.RemoveAt(i);
                //continue;
            }
            else
            {
                enemiesInRange.Add(enemiesClose[i]);

            }
            
        }
        
        if (enemiesInRange.Count == 0)
        {
            closestEnemy = null;
            return;
        } 
        
        closestEnemy = enemiesInRange[0];

        float closestEnemyDist = Vector2.Distance(player.transform.position, closestEnemy.transform.position);


        foreach (GameObject enemy in enemiesInRange)
        {

            float dist = Vector2.Distance(player.transform.position, enemy.transform.position);

            if (dist < closestEnemyDist)
            {
                closestEnemy = enemy;
                //Debug.Log(closestEnemy.name);
            }
        }

    }//End ClosestEnemy



}//END CLASS
