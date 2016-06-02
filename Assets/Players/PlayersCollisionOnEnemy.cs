using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayersCollisionOnEnemy : MonoBehaviour {

    [Header("Scripts")]
    public GameManager gameManager;
    public PlayersMovements playerMovement;

    //JOINTS when enemy touch player
    public List<DistanceJoint2D> jointList = new List<DistanceJoint2D>();
    DistanceJoint2D joint;
    DistanceJoint2D[] joints; //Array to store number of joints
    public float jointBreakForce;


    //Not sure if will be used
    public List<GameObject> enemiesStuck = new List<GameObject>();


    //Timer for loose points
    public float loosePointRate;
    public float loosePointTimer;

    //Related to the power charging when trying to get rid of enemy
    public Image powerBar;
    public float breakPowerMax;
    public float breakPower;

    [System.Serializable]
    public class OnPointLost : UnityEvent<string> { };
    public OnPointLost onPointLost;

    // Use this for initialization
    void Start()
    {
        loosePointRate = 2;
        
    }

    void Update()
    {
        loosePointTimer += Time.deltaTime;

    }//END UPDATE

    //When an ENEMY collide with the player
    //It creat a joint - the ENEMY will EAT the player points
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Remove unecessary joint in the list
            for (int i = jointList.Count - 1; i >= 0; i--)
            {
                if (jointList[i] == null)
                {
                    jointList.RemoveAt(i);

                }
            }

            joint = gameObject.AddComponent<DistanceJoint2D>();
            joint.connectedBody = collision.rigidbody;
            joint.distance = 0.5f;
            joint.breakForce = jointBreakForce;
            jointList.Add(joint);

        }
    }

    //Loose point each (loosePointRate) secondes AND for each ENEMY stuck on player
    public void LoosePoints()
    {
        if (GetComponent<DistanceJoint2D>())
        {
            if (loosePointTimer >= loosePointRate)
            {
   
                foreach (DistanceJoint2D joint in jointList)
                {
                    onPointLost.Invoke("");
                }
                
                loosePointTimer = 0;
            }
        }
    }

    //Shake the player to get rid of anoying ENEMY
    //SPAM button to charge power
   // public void ShakeToBreak(KeyCode keycode)
    public void ShakeToBreak(string button)
    {
        if (Input.GetButton(button))
        {
            if (GetComponent<DistanceJoint2D>())
            {
                transform.DOShakePosition(.5f, .1f, 10, 45);
                breakPower += 20f;

                if (breakPower >= breakPowerMax)
                {
                    PushEnemy();
                    breakPower = 0;
                }
            }
        }

        if (breakPower > 0) { breakPower--; }
        powerBar.fillAmount = breakPower / breakPowerMax;
        
    }

    public void KShakeToBreak(KeyCode button)
    {
        if (Input.GetKeyDown(button))
        {
            if (GetComponent<DistanceJoint2D>())
            {
                transform.DOShakePosition(.5f, .1f, 10, 45);
                breakPower += 20f;

                if (breakPower >= breakPowerMax)
                {
                    PushEnemy();
                    breakPower = 0;
                }
            }
        }

        if (breakPower > 0) { breakPower--; }
        powerBar.fillAmount = breakPower / breakPowerMax;

    }

    //When player reach max power, PUSH ENEMY AWAY
    public void PushEnemy()
    {
        transform.DOShakePosition(.1f, .3f, 30, 90).OnComplete(BreakJoint);
        
        foreach (DistanceJoint2D joint in jointList)
        {
            //Push enemies away
            joint.distance = 5;
        }
    }

    //Break the joints on the player that connected the ENEMY on him
    public void BreakJoint()
    {
        foreach (DistanceJoint2D joint in jointList)
        {

            Destroy(joint);
            playerMovement.StopMovement();
            
        }

        jointList.Clear();

    }

    

    
}//CLASS END
