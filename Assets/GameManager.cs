using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [Header("Scripts")]
    public EnemySpawner enemySpawner;
    public Malario malario;
    public Pestus pestus;

    [Header("GameObject")]
    public GameObject[] pestusParts;
    public GameObject[] malarioParts;
    public GameObject[] points;

    public float time;
    public float gameTime;

    public bool gameFinished;

    public int malarioScore;
    public int pestusScore;

    public int malarioLevel;
    public int pestusLevel;
    public int playersMaxLevel;

    //Control how many point we need to lvl up
    public int modulo;
    

    public UnityEvent OnScoreUpdate = new UnityEvent();
    public UnityEvent OnLevelUpdate = new UnityEvent();
    public UnityEvent OnGameFinished = new UnityEvent();

    // Use this for initialization
    void Start ()
    {
        time = 0;
        gameFinished = false;
        malarioLevel = 1;
        pestusLevel = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
       if(!gameFinished) time = gameTime-Time.timeSinceLevelLoad;//gameTime - Time.time;
       GameFinished();
    }

    private void GameFinished()
    {
        if (time <= 0)
        {
            OnGameFinished.Invoke();
            gameFinished = true;
            //Stop spawning
            enemySpawner.enabled = false;
            //Disable players script so they dont act anymore
            pestusParts[0].GetComponent<Player>().enabled = false;
            pestusParts[0].GetComponent<PlayersCollisionOnEnemy>().enabled = false;
            malarioParts[0].GetComponent<Player>().enabled = false;
            malarioParts[0].GetComponent<PlayersCollisionOnEnemy>().enabled = false;

        }
    }

    public void ResetGame()
    {
        //Do Something
        /*time = gameTime;
        enemySpawner.KillAllVirus();
        malarioScore = 0;
        malarioLevel = 1;

        pestusScore = 0;
        pestusLevel = 1;

        gameFinished = false;*/
        SceneManager.LoadScene("main");
    }

    public void OnUpdateScore(string player)
    {
        
        //Update Malario Score
        if (player == "M+")
        {
            malarioScore++;
            
        }
        if (player == "M-")
        {
            if (malarioScore <= 0) { malarioScore = 0; return; }
            malarioScore--;
        }


        //Update Pestus Score
        if (player == "P+")
        {
            pestusScore++;
            Instantiate(points[0], pestus.transform.position + Vector3.up, transform.rotation);
        }

        if (player == "P-")
        {
            if (pestusScore <= 0) { pestusScore = 0; return; }
            pestusScore--;
        }

        OnScoreUpdate.Invoke();

    }

    public void OnLevelCheck(string player)
    {
        
        if (player == "M")
        {
            if (malarioLevel >= playersMaxLevel) return;
            //Check if the condition is met to lvl up the player
            if (malarioScore > 0 && malarioScore % modulo == 0)
            {
                //Yes! Gain a level
                malarioLevel++;
                malario.GetComponent<Player>().level++;

                //Modify the apparence of the player
                switch (malarioLevel)
                {
                    case 2:
                        malarioParts[2].SetActive(true);
                        malarioParts[0].transform.localScale = new Vector3(.4f, .4f, .4f);
                        malarioParts[1].transform.localScale = new Vector3(.4f, .4f, .4f);
                        break;

                    case 3:
                        //malarioParts[3].SetActive(true);
                        malarioParts[0].transform.localScale = new Vector3(.8f, .8f, .8f);

                        break;
                }
            }
        }

       if (player == "P")
        {
            if (pestusLevel >= playersMaxLevel) return;
            if (pestusScore > 0 && pestusScore % modulo == 0)
            {
                pestusLevel++;
                pestus.GetComponent<Player>().level++;

                switch (pestusLevel)
                {
                    case 2:
                        pestusParts[2].SetActive(true);
                        pestusParts[0].transform.localScale = new Vector3(.4f, .4f, .4f);
                        pestusParts[1].transform.localScale = new Vector3(.4f, .4f, .4f);
                        break;

                    case 3:
                        //pestusParts[3].SetActive(true);
                        pestusParts[0].transform.localScale = new Vector3(.8f, .8f, .8f);

                        break;
                }
            }

        }

        //Things happend when player level up
        OnLevelUpdate.Invoke();
    }
}
