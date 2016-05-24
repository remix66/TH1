using UnityEngine;
using System.Collections;
using UnityEngine.Events;


public class SpikeAttack : MonoBehaviour {

    public float pushForce;
   
    [System.Serializable]
    public class OnKillEnemy : UnityEvent<string> { };
    public OnKillEnemy onKillEnemy;


    

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            onKillEnemy.Invoke("");
        }

        if (other.gameObject.CompareTag("Player"))
        {

            Vector2 direction = (other.gameObject.transform.position - transform.position).normalized;

            other.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * pushForce, ForceMode2D.Impulse);
            
        }
    }
}
