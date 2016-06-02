using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class PlayersSkills : MonoBehaviour {

    [Header("Scripts")]
    public PlayersMovements playerMovement;
    public EnemyDetector enemyDetector;
    public SingleSpike singleSpike;
    public MultipleSpike multipleSpike;
   

    [Header("GameObjects")]
    public GameObject shield;
    
    [Header("Scripts")]
    //

    //Timer For single spike attack
    public float attackRate;
    public float attackTimer;

    //For Rotating spike attack
    public bool isSpinningAttack;

    //Timer for shield
    public float shieldRate;
    public float shieldTimer;
    public bool isShielding;
    
    

    public UnityEvent OnShieldUp = new UnityEvent();
    public UnityEvent OnShieldDown = new UnityEvent();

    // Use this for initialization
    void Start ()
    {
        attackRate = 1;
        shieldRate = 1;
        isShielding = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        attackTimer += Time.deltaTime;
        shieldTimer += Time.deltaTime;


    }
    //TODO someday : Cant attack a virus stuck on your player enemy
    public void SpikeAttack(string button)
    {

        //if (Input.GetKeyDown(keyCode) && attackTimer >= attackRate && !isShielding)
        if (Input.GetButton(button) && attackTimer >= attackRate && !isShielding)
        {
            
            if (!GetComponent<DistanceJoint2D>())
            {
                
                if (enemyDetector.closestEnemy != null)
                {
                    singleSpike.Attack(enemyDetector.closestEnemy);
                    attackTimer = 0;
                    enemyDetector.enemiesClose.Clear();
                    enemyDetector.closestEnemy = null;
                }
            }

        }

    }

    public void KSpikeAttack(KeyCode button)
    {

        if (Input.GetKeyDown(button) && attackTimer >= attackRate && !isShielding)
        {
            if (!GetComponent<DistanceJoint2D>())
            {

                if (enemyDetector.closestEnemy != null)
                {
                    singleSpike.Attack(enemyDetector.closestEnemy);
                    attackTimer = 0;

                }
            }
        }
    }

    //Attack on sight
    public void SingleSpikeAttack()
    {
        if(attackTimer >= attackRate && !isShielding)
        {
            if (!GetComponent<DistanceJoint2D>())
            {
                if (enemyDetector.closestEnemy != null)
                {
                    singleSpike.Attack(enemyDetector.closestEnemy);
                    attackTimer = 0;

                }

            }
        }
    }

    //Triggered by eating a RedCell
    public void MultipleSpikeAttack()
    {
        if (isSpinningAttack)
        {
            multipleSpike.RotateSpike();
        }
    }

    //public IEnumerator ActivateShield(KeyCode keyCode)
    public IEnumerator ActivateShield(string button)
    {
       // if (Input.GetKeyDown(keyCode) && shieldTimer >= shieldRate)
        if (Input.GetButton(button) && shieldTimer >= shieldRate)
        {
            if (!GetComponent<DistanceJoint2D>())
            {
                shield.SetActive(true);
                isShielding = true;
                OnShieldUp.Invoke();  //Event sent to PlayersMovements
                yield return new WaitForSeconds(3);
                OnShieldDown.Invoke(); //Event sent to PlayersMovements
                isShielding = false;
                shield.SetActive(false);
                shieldTimer = 0;
            }
        }
    }

    public IEnumerator KActivateShield(KeyCode button)
    {
        // if (Input.GetKeyDown(keyCode) && shieldTimer >= shieldRate)
        if (Input.GetKeyDown(button) && shieldTimer >= shieldRate)
        {
            if (!GetComponent<DistanceJoint2D>())
            {
                shield.SetActive(true);
                isShielding = true;
                OnShieldUp.Invoke();  //Event sent to PlayersMovements
                yield return new WaitForSeconds(3);
                OnShieldDown.Invoke(); //Event sent to PlayersMovements
                isShielding = false;
                shield.SetActive(false);
                shieldTimer = 0;
            }
        }
    }


}
