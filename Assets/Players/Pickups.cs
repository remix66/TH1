using UnityEngine;
using System.Collections;

public class Pickups : MonoBehaviour {

    [Header("Scripts")]
    public MultipleSpike multipleSpike;
    public PlayersSkills playerSkill;
    // Use this for initialization
    void Start () {
	
	}


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            multipleSpike.attackActivated = true;
            Destroy(collision.gameObject);
        }
    }
}
