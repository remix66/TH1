using UnityEngine;
using System.Collections;

public class Pestus : MonoBehaviour
{

   [Header("Scripts")]
   public PlayersMovements playerMovement;
   public PlayersSkills playerSkill;
   public PlayersCollisionOnEnemy playerCollisionOnEnemy;

   public int level;
    // Use this for initialization
    void Start ()
    {
        level = 1;
	}

    void Update()
    {

       // playerSkill.SpikeAttack(KeyCode.Space);
       // StartCoroutine(playerSkill.ActivateShield(KeyCode.Q));

        //playerCollisionOnEnemy.ShakeToBreak(KeyCode.E);
        playerCollisionOnEnemy.LoosePoints();
    }

    void FixedUpdate()
    {

        playerMovement.Move("HorizontalP", "VerticalP");
    }

    public void LevelUp()
    {
        level++;
    }
}
