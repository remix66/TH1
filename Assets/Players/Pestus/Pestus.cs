using UnityEngine;
using System.Collections;

public class Pestus : MonoBehaviour
{

   [Header("Scripts")]
   public PlayersMovements playerMovement;
   public PlayersSkills playerSkill;
   public PlayersCollisionOnEnemy playerCollisionOnEnemy;

    // Use this for initialization
    void Start () {
	
	}

    void Update()
    {

        playerSkill.SpikeAttack(KeyCode.Space);
        StartCoroutine(playerSkill.ActivateShield(KeyCode.Q));

        playerCollisionOnEnemy.ShakeToBreak(KeyCode.E);
        playerCollisionOnEnemy.LoosePoints();
    }

    void FixedUpdate()
    {

        playerMovement.Move("HorizontalP", "VerticalP");
    }
}
