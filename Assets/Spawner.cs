using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public EnemySpawner enemySpawner;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            enemySpawner.canSpawn = false;

        }
    }

    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            enemySpawner.canSpawn = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

            enemySpawner.canSpawn = true;

        }
    }
}
