using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

   [Header("Scripts")]
   public PlayersMovements playerMovement;
   public PlayersSkills playerSkill;
   public PlayersCollisionOnEnemy playerCollisionOnEnemy;

   private Transform player;
    

   public int level;
    // Use this for initialization
    void Start ()
    {
        player = transform.root;
        level = 1;
	}

    void Update()
    {

        playerCollisionOnEnemy.LoosePoints();
    }

    void FixedUpdate()
    {
        PlayerControls();
    }

    public void LevelUp()
    {
        level++;
    }

    private void PlayerControls()
    {
        if (player.name == "Pestus")
        {
            playerMovement.Move("KPH", "KPV");
            playerSkill.KSpikeAttack(KeyCode.Space);
            StartCoroutine(playerSkill.KActivateShield(KeyCode.Q));
            playerCollisionOnEnemy.KShakeToBreak(KeyCode.E);
        }
        else
        {
            playerMovement.Move("KMH", "KMV");
            playerSkill.KSpikeAttack(KeyCode.KeypadEnter);
            StartCoroutine(playerSkill.KActivateShield(KeyCode.Keypad3));
            playerCollisionOnEnemy.KShakeToBreak(KeyCode.KeypadPeriod);
        }
    }
}
