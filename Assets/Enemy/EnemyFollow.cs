using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour
{

    public Enemy enemy;
    public GameObject player;
    private Transform virus;
    public float playerDistance;

    public float rotationDamping;


    //public float aggroLookAtDistance;
    //public float aggroChaseDistance;
    public float aggroStopChasingDistance;

    public float moveSpeed;
    private bool foundTarget;

    // Use this for initialization

    void Start()
    {
        //When a player level up check if the virus stop following him
        foundTarget = false;
        virus = transform.root;
        aggroStopChasingDistance = 10f;
        moveSpeed = 1.2f;
    }

    // Update is called once per frame
    void Update()
    {

        if (foundTarget)
        {
            FollowPlayer();

            playerDistance = Vector2.Distance(player.GetComponent<Transform>().position, transform.position);

            if (playerDistance >= aggroStopChasingDistance /*|| virus.GetComponent<Enemy>().level == player.*/)
            {
                //Virus stop chasing player
                ResetAgro();

            }

        }

    }

    
    void OnTriggerEnter2D(Collider2D other)
     {

         if (other.gameObject.CompareTag("Player"))
         {
            
            enemy.isChasing = true;
            player = other.gameObject;
            foundTarget = true;
            //enemy.StopMovement();
        }
     }

    private void ResetAgro()
    {
        foundTarget = false;
        player = null;
        enemy.isChasing = false;
    }

    private void LookAtPlayer()
    {
       //

    }//fin FCT Regarderplayer


    private void FollowPlayer()
    {
        virus.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }//fin FCT Pourchasser


}



