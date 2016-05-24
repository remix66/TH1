using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

    [Header("Scripts")]
    public EnemySpawner enemySpawner;

    [Header("GameObject")]
    public GameObject[] pestusParts;
    public GameObject[] malarioParts;

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
        time = gameTime - Time.time;
        GameFinished();
    }

    private void GameFinished()
    {
        if (time <= 0)
        {
            
            gameFinished = true;
            //Stop spawning
            enemySpawner.enabled = false;
            //Disable players script so they dont act anymore
            pestusParts[0].GetComponent<Pestus>().enabled = false;
            pestusParts[0].GetComponent<PlayersCollisionOnEnemy>().enabled = false;
            malarioParts[0].GetComponent<Malario>().enabled = false;
            malarioParts[0].GetComponent<PlayersCollisionOnEnemy>().enabled = false;
        }
    }

    public void ResetGame()
    {
        //Do Something
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

                //Modify the apparence of the player
                switch (malarioLevel)
                {
                    case 2:
                        malarioParts[2].SetActive(true);
                        malarioParts[1].transform.localScale = new Vector3(.5f,.5f,.5f);
                        break;

                    case 3:
                        //malarioParts[3].SetActive(true);
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

                switch (pestusLevel)
                {
                    case 2:
                        pestusParts[2].SetActive(true);
                        pestusParts[1].transform.localScale = new Vector3(.5f, .5f, .5f);
                        break;

                    case 3:
                        //pestusParts[3].SetActive(true);
                        break;
                }
            }

        }

        //Things happend when player level up
        OnLevelUpdate.Invoke();
    }
}
