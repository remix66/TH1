using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class MultiSpikeAttack : MonoBehaviour {


    public GameObject player;
    public DistanceJoint2D[] joints;
    public float pushForce;

    [System.Serializable]
    public class OnKillEnemy : UnityEvent<string> { };
    public OnKillEnemy onKillEnemy;

    // Use this for initialization
    void Start ()
    {
        pushForce = 10f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Vector2 direction = (other.gameObject.transform.position - transform.position).normalized;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * pushForce, ForceMode2D.Impulse);
        }
        
    }
}
