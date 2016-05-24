using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public float speed;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public int level;
    //Random movement
    public float moveHorizontal;
    public float moveVertical;

    public bool isChasing;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        speed = Random.Range(0.1f, 0.3f);
        moveHorizontal = Random.Range(-3f, 3f);
        moveVertical = Random.Range(-3f, 3f);
        InvokeRepeating("RandomizeMovement",0,3);
        isChasing = false;
    }


    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        if (!isChasing)
        {
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb2d.AddForce(movement * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Background"))
        {
            RandomizeMovement(); 
        }
    }

    void RandomizeMovement()
    {
        moveHorizontal = Random.Range(-3f, 3f);
        moveVertical = Random.Range(-3f, 3f);
        speed = Random.Range(0.1f, 0.3f);
 
    }

    public void StopMovement() { rb2d.velocity = new Vector3(0, 0, 0); }
}
