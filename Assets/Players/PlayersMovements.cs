using UnityEngine;
using System.Collections;

public class PlayersMovements : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed;

    public float startMass;
    public float shieldMass;
    
    //public float rotationSpeed;

    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        startMass = 1;
        shieldMass = 6;
    }

    void Update() { }

    public void Move(string h, string v)
    {
       
        float moveHorizontal = Input.GetAxis(h);

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis(v);

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    public void StopMovement() { rb2d.velocity = new Vector3(0, 0, 0); }

    public void OnShielUp()
    {
        rb2d.mass = shieldMass;
    }
    public void OnShieldDown()
    {
        rb2d.mass = startMass;
    }

}
