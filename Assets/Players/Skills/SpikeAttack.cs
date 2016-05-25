using UnityEngine;
using System.Collections;
using UnityEngine.Events;


public class SpikeAttack : MonoBehaviour {

    public float pushForce;
    public Player player;
    private string playerMainScript;
   
    [System.Serializable]
    public class OnKillEnemy : UnityEvent<string> { };
    public OnKillEnemy onKillEnemy;

    void Start()
    {

        
    }
    

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.GetComponent<Enemy>().level > player.level)
            {
                PushBack(other);
            }
            else
            {
                Destroy(other.gameObject);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                onKillEnemy.Invoke("");
            }
            
        }

        if (other.gameObject.CompareTag("Player"))
        {
            PushBack(other);
        }
    }

    public void PushBack(Collider2D other)
    {
        Vector2 direction = (other.gameObject.transform.position - transform.position).normalized;
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * pushForce, ForceMode2D.Impulse);
    }
}
