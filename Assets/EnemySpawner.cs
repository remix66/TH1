using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public GameManager gameManager;
    public GameObject[] enemies;
    public GameObject whiteCell;
    public GameObject redCell;
    public int minRnd;
    public int maxRnd;

    public float spawnRate;
    public float spawnDistance;
    public int spawnRedCellRdn;

    private float timer;

    
    public int malarioLvl;
    public int pestusLvl;

	// Use this for initialization
	void Start ()
    {
        malarioLvl = 1;
        pestusLvl = 1;

        minRnd = 0;
        maxRnd = 3;

        //spawnCounter = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {
        EnemySpawn();


    }

    public void EnemySpawn()
    {

        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            spawnRedCellRdn = Random.Range(0, 4);
            int rndNbSpawn = Random.Range(0, 3);
           
            for (int i = rndNbSpawn; i > 0; i--)
            {
                int rndEnemy = Random.Range(minRnd, maxRnd);
                GameObject enemy = Instantiate(enemies[rndEnemy]);

                float angle = Random.value * Mathf.PI * 20;
                enemy.transform.position = new Vector3(Mathf.Cos(angle) * (spawnDistance + Random.value * 10), 0f, Mathf.Sin(angle) * (spawnDistance + Random.value * 10));

            }

            timer = 0;

        }

        if (spawnRedCellRdn == 2 && (gameManager.malarioLevel == 2 || gameManager.pestusLevel == 2))
        {
            spawnRedCellRdn = 0;
            float angle = Random.value * Mathf.PI * 10;
            Instantiate(redCell, new Vector3(Mathf.Cos(angle) * (spawnDistance + Random.value * 5), 0f, Mathf.Sin(angle) * (spawnDistance + Random.value * 5)), Quaternion.identity);
        }

    }

    public void AddVirusToArray()
    {
        if (gameManager.malarioLevel == 2 || gameManager.pestusLevel == 2)
        {

            //Add all level 2 virus reduce all bit lvl 1 spawn
            //maxRnd = 4;
        }

        if (gameManager.malarioLevel == 3 || gameManager.pestusLevel == 3)
        {
            //Add all level 3 virus reduce lvl 2 and lvl 1
            // maxRnd = 4; //9
        }
    }
}
