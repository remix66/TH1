using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    public GameManager gameManager;
    public GameObject[] enemies;
    public Transform[] spawnPoints;
    public GameObject whiteCell;
    public GameObject redCell;
    public List<GameObject> virus = new List<GameObject>();
    public int minRnd;
    public int maxRnd;

    public float spawnRate;
    public float spawnDistance;
    public int spawnRedCellRdn;

    private float timer;
    public bool canSpawn;

    
    public int malarioLvl;
    public int pestusLvl;

	// Use this for initialization
	void Start ()
    {
        malarioLvl = 1;
        pestusLvl = 1;

        minRnd = 0;
        maxRnd = 3;

        canSpawn =  true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        EnemySpawn();


    }

    public void EnemySpawn()
    {

        timer += Time.deltaTime;
        if (canSpawn)
        { 
            if (timer >= spawnRate)
            {
                spawnRedCellRdn = Random.Range(0, 4);
                int rndNbSpawn = Random.Range(0, 2);
                int rndSpawnPoint = Random.Range(0, 7);

                for (int i = rndNbSpawn; i > 0; i--)
                {
                    int rndEnemy = Random.Range(minRnd, maxRnd);
                    GameObject enemy = Instantiate(enemies[rndEnemy]);
                    virus.Add(enemy);
                    enemy.transform.position = spawnPoints[rndSpawnPoint].transform.position;
                }

                timer = 0;

            }

            if (spawnRedCellRdn == 2 && (gameManager.malarioLevel == 2 || gameManager.pestusLevel == 2))
            {

                int rndSpawnPoint = Random.Range(0, 7);
                spawnRedCellRdn = 0;
                GameObject rc = Instantiate(redCell);
                rc.transform.position = spawnPoints[rndSpawnPoint].transform.position;
            }
        }
    }

    public void AddVirusToArray()
    {
        if (gameManager.malarioLevel == 2 || gameManager.pestusLevel == 2)
        {

            //Add all level 2 virus reduce all bit lvl 1 spawn
            maxRnd = 6;
        }

        if (gameManager.malarioLevel == 3 || gameManager.pestusLevel == 3)
        {
            //Add all level 3 virus reduce lvl 2 and lvl 1
            minRnd = 6;
            maxRnd = 9;
        }
    }

    public void KillAllVirus()
    {
        foreach (GameObject v in virus)
        {
            if (v != null)
            {
                Destroy(v);
            }  
        }
    }
}
