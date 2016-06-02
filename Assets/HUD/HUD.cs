using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class HUD : MonoBehaviour {

    public GameManager gameManager;
    public GameObject replay;
    public Text time;
    public Text pestusScore;
    public Text malarioScore;

    public Text pestusLevel;
    public Text malarioLevel;

   

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        time.text = Mathf.RoundToInt(gameManager.time).ToString();
    }

    public void Reload()
    {
        
    }


    public void UpdateScore()
    {
        pestusScore.text = gameManager.pestusScore.ToString();
        malarioScore.text = gameManager.malarioScore.ToString();
    }

    public void UpdateLevel()
    {
        pestusLevel.text = "Level " + gameManager.pestusLevel.ToString();
        malarioLevel.text = "Level " + gameManager.malarioLevel.ToString();
    }

    public void OnShowReplayButton()
    {
        replay.SetActive(true);
    }
}
