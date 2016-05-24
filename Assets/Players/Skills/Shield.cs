using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {

    private CircleCollider2D shieldCol;
    public SpriteRenderer shieldRenderer;
    private Transform enemyPlayer;
    public Transform player;
    public float pushForce;

	// Use this for initialization
	void Start ()
    {
        shieldCol = GetComponent<CircleCollider2D>();
        pushForce = 10;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("SingleSpike"))
        {
            //TODO : find another way to do that
            if (other.gameObject.CompareTag("SingleSpike"))
            {
                enemyPlayer = other.gameObject.transform.root;
                Vector2 dir = enemyPlayer.transform.position - transform.position;
                enemyPlayer.GetComponent<Rigidbody2D>().AddForce(dir * pushForce, ForceMode2D.Impulse);

                return;
            }

            //If other then the spike
            Vector2 direction = (other.gameObject.transform.position - transform.position).normalized;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * pushForce, ForceMode2D.Impulse);

        }


    }

}
