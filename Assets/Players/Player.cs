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
            playerMovement.Move("HorizontalP", "VerticalP");
            playerSkill.SpikeAttack(KeyCode.Space);
            StartCoroutine(playerSkill.ActivateShield(KeyCode.Q));
            playerCollisionOnEnemy.ShakeToBreak(KeyCode.E);
        }
        else
        {
            playerMovement.Move("HorizontalM", "VerticalM");
            playerSkill.SpikeAttack(KeyCode.KeypadEnter);
            StartCoroutine(playerSkill.ActivateShield(KeyCode.Keypad3));
            playerCollisionOnEnemy.ShakeToBreak(KeyCode.KeypadPeriod);
        }
    }
}
