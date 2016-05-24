using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Malario : MonoBehaviour
{

    [Header("Scripts")]
    public PlayersMovements playerMovement;
    public PlayersSkills playerSkills;
    public PlayersCollisionOnEnemy playerCollisionOnEnemy;

    // Use this for initialization
    void Start ()
    {
       

    }

    void Update()
    {

        //Skills
        playerSkills.SpikeAttack(KeyCode.KeypadEnter);
        StartCoroutine(playerSkills.ActivateShield(KeyCode.Keypad3));
        
        playerCollisionOnEnemy.ShakeToBreak(KeyCode.KeypadPeriod);
        playerCollisionOnEnemy.LoosePoints();
        

    }

    void FixedUpdate()
    {

        playerMovement.Move("HorizontalM", "VerticalM");
    }

   



}
